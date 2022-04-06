using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Globalization;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Drawing.Text;

namespace grayemo
{
    
    public partial class Form1 : Form
    {

        DataSet data = new DataSet();

        Dictionary<string, object> dataSettings = new Dictionary<string, object>();

        BindingList<string> names;
        BindingList<string> prcToKill;
        BindingList<string> prcToRun;
        BindingList<string> runOnStart;
        BindingList<string> runOnExit;

        Dictionary<string, string> lng = new Dictionary<string, string>();

        string gameSelected = "";

        string listNameSelected = "";

        public static bool darkTheme;

        public static bool showWelcomeForm = false;

        Color colorAccent = Color.FromArgb(255, 112, 147, 106);
        public static Color bkgColor;
        public static Color frgColor;

        [DllImport("dwmapi.dll")]

        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]

        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;

        //-- FORM INITIALIZATION --

        public Form1()
        {

            Int32 check = (Int32) Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize", "AppsUseLightTheme", null);

            string jsonString = "";

            if (File.Exists("data.json"))
                jsonString = File.ReadAllText("data.json");

            if (jsonString.Length != 0) data = JsonSerializer.Deserialize<DataSet>(jsonString);

            dataSettings["autoclean"] = "false";
            dataSettings["lng"] = CultureInfo.CurrentUICulture.Name;
            dataSettings["dark_thm"] = check == 0 ? "true" : "false";
            dataSettings["welcome"] = "true";
            dataSettings["autoload"] = "false";

            initializeData();

            darkTheme = data.settings["dark_thm"] == "true" ? true : false;

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Convert.ToString(data.settings["lng"]));

            names = new BindingList<string>(data.games.Select(x => x.name).ToList());

            if (darkTheme)
                setWindowTitleColor();

            InitializeComponent();

            byte[] fontData = Properties.Resources.Andika_Regular;

            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);

            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            uint dummy = 0;

            fonts.AddMemoryFont(fontPtr, Properties.Resources.Andika_Regular.Length);

            AddFontMemResourceEx(fontPtr, (uint) Properties.Resources.Andika_Regular.Length, IntPtr.Zero, ref dummy);

            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 8.25F);

            this.Font = myFont;

            bkgColor = darkTheme ? Color.Black : Color.White;
            frgColor = darkTheme ? Color.White : Color.Black;

            setTheme(Controls);

            updatePrc(new List<string>(), new List<string>(), new List<string>(), new List<string>());

            lng.Add(CultureInfo.GetCultureInfo("en-US").NativeName, "en-US");
            lng.Add(CultureInfo.GetCultureInfo("ru-RU").NativeName, "ru-RU");
            lng.Add(CultureInfo.GetCultureInfo("uk-UA").NativeName, "uk-UA");

            lngComboBox.Items.AddRange(lng.Keys.ToArray());

            gamesListBox.DataSource = names;

            gamesListBox.SelectedItems.Clear();

            lngComboBox.SelectedIndex = lngComboBox.Items.IndexOf(CultureInfo.CurrentUICulture.NativeName);

            autoclnCheckBox.Checked = data.settings["autoclean"] == "true" ? true : false;
            autoloadCheckBox.Checked = data.settings["autoload"] == "true" ? true : false;

            darkThmCheckBox.Checked = darkTheme;

            if (data.settings["welcome"] == "true") showWelcomeForm = true;

            if (showWelcomeForm)
            {

                Form welcomeForm = new WelcomeForm();

                welcomeForm.Show();

            }

        }

        //-- ADD ITEM --

        private void onItemAdded(object sender, EventArgs e)
        {

            if (listNameSelected == "gamesListBox")
            {

                if (textBox.Text.Length > 0 && !names.Contains(textBox.Text))
                {

                    if (gameSelected.Length == 0)
                    {

                        data.games.Add(new Game(textBox.Text));

                        names.Add(textBox.Text);

                    }
                    else
                    {

                        names[data.games.FindIndex(x => x.name == gameSelected)] = textBox.Text;

                        data.games[data.games.FindIndex(x => x.name == gameSelected)].name = textBox.Text;

                        gameSelected = textBox.Text;

                    }
                }
            }

            bool isPresentedInPrc = prcToKill.Contains(textBox.Text) || prcToRun.Contains(textBox.Text)
                || runOnStart.Contains(textBox.Text) || runOnExit.Contains(textBox.Text);


            if (listNameSelected == "prcToKillListBox" && gameSelected != "")
            {

                if (textBox.Text.Length > 0 && !isPresentedInPrc)
                {

                    if ((string)prcToKillListBox.SelectedItem == null) prcToKill.Add(textBox.Text);
                    else
                        prcToKill[prcToKillListBox.SelectedIndex] = textBox.Text;

                }
            }

            if (listNameSelected == "prcToRunListBox" && gameSelected != "")
            {

                if (textBox.Text.Length > 0 && !isPresentedInPrc)
                {

                    if ((string)prcToRunListBox.SelectedItem == null) prcToRun.Add(textBox.Text);
                    else
                        prcToRun[prcToRunListBox.SelectedIndex] = textBox.Text;

                }
            }

            if (listNameSelected == "runOnStartListBox" && gameSelected != "")
            {

                if (textBox.Text.Length > 0 && !isPresentedInPrc)
                {

                    if ((string)runOnStartListBox.SelectedItem == null) runOnStart.Add(textBox.Text);
                    else
                        runOnStart[runOnStartListBox.SelectedIndex] = textBox.Text;

                }
            }

            if (listNameSelected == "runOnExitListBox" && gameSelected != "")
            {

                if (textBox.Text.Length > 0 && !isPresentedInPrc)
                {

                    if ((string)runOnExitListBox.SelectedItem == null) runOnExit.Add(textBox.Text);
                    else
                        runOnExit[runOnExitListBox.SelectedIndex] = textBox.Text;

                }
            }

            if (data.settings["autoclean"] == "true") textBox.Text = "";

            serialize();

        }

        //-- DELETE ITEM --

        private void onItemDeleted(object sender, EventArgs e)
        {

            if (gamesListBox.SelectedItem != null && prcToKillListBox.SelectedItem == null && prcToRunListBox.SelectedItem == null
                && runOnStartListBox.SelectedItem == null && runOnExitListBox.SelectedItem == null)
            {

                gameSelected = "";

                data.games.RemoveAll(x => x.name == gamesListBox.SelectedItem.ToString());
                names.Remove(gamesListBox.SelectedItem.ToString());
                prcToKill.Clear();
                prcToRun.Clear();

            }
            if (prcToKillListBox.SelectedItem != null)
            {

                prcToKill.Remove(prcToKillListBox.SelectedItem.ToString());

            }
            if (prcToRunListBox.SelectedItem != null)
            {

                prcToRun.Remove(prcToRunListBox.SelectedItem.ToString());

            }
            if (runOnStartListBox.SelectedItem != null)
            {

                runOnStart.Remove(runOnStartListBox.SelectedItem.ToString());

            }
            if (runOnExitListBox.SelectedItem != null)
            {

                runOnExit.Remove(runOnExitListBox.SelectedItem.ToString());

            }

            if ((sender as ListBox) != null)
                (sender as ListBox).SelectedItems.Clear();

            removeButton.Enabled = false;

            if (data.settings["autoclean"] == "true") textBox.Text = "";

            serialize();

        }

        //-- DESSELECT ITEM --

        private void onItemDesselected(object sender, EventArgs e)
        {

            if (gamesListBox.Focused || gamesButton.Focused)
            {

                listNameSelected = "";

                gameSelected = "";

                setEnableButtons(false);

                removeButton.Enabled = false;

                prcToKill = new BindingList<string>();
                prcToRun = new BindingList<string>();
                runOnStart = new BindingList<string>();
                runOnExit = new BindingList<string>();

                prcToKillListBox.DataSource = prcToKill;
                prcToRunListBox.DataSource = prcToRun;
                runOnStartListBox.DataSource = runOnStart;
                runOnExitListBox.DataSource = runOnExit;

            }
            else
            {

                if (gameSelected.Length != 0)
                {

                    listNameSelected = "gamesListBox";
                    gamesListBox.SelectedIndex = names.IndexOf(gameSelected);

                    removeButton.Enabled = true;

                }
            }



            if (sender is ListBox)
                (sender as ListBox).SelectedItems.Clear();

            else
            {

                if ((sender as Button).Name == "gamesButton")
                    gamesListBox.SelectedItems.Clear();

                if ((sender as Button).Name == "prcToKillButton")
                    prcToKillListBox.SelectedItems.Clear();

                if ((sender as Button).Name == "prcToRunButton")
                    prcToRunListBox.SelectedItems.Clear();

                if ((sender as Button).Name == "runOnStartButton")
                    runOnStartListBox.SelectedItems.Clear();

                if ((sender as Button).Name == "runOnExitButton")
                    runOnExitListBox.SelectedItems.Clear();

            }


            if (data.settings["autoclean"] == "true") textBox.Text = "";

            setLabelsColor();

        }

        //-- CHANGE ITEM --

        private void onItemChanged(object sender, EventArgs e)
        {

            if (gamesListBox.Focused || gamesButton.Focused)
            {

                setEnableButtons(true);

                if (gamesListBox.SelectedItem != null && gamesListBox.SelectedItem.ToString() != "")
                {

                    gameSelected = gamesListBox.SelectedItem.ToString();

                    textBox.Text = gameSelected;

                    Game rawGameSelected = data.games.Find(x => x.name == gamesListBox.SelectedItem.ToString());

                    updatePrc(rawGameSelected.prcToKill, rawGameSelected.prcToRun,
                        rawGameSelected.runOnStart, rawGameSelected.runOnExit);

                    removeButton.Enabled = true;

                }

                prcToKillListBox.SelectedItems.Clear();
                prcToRunListBox.SelectedItems.Clear();
                runOnStartListBox.SelectedItems.Clear();
                runOnExitListBox.SelectedItems.Clear();

            }
            if (prcToKillListBox.Focused || prcToKillButton.Focused)
            {

                if (prcToKillListBox.SelectedItem != null)
                {

                    prcToRunListBox.SelectedItems.Clear();
                    runOnStartListBox.SelectedItems.Clear();
                    runOnExitListBox.SelectedItems.Clear();

                }

                if (prcToKillListBox.SelectedItem != null && prcToKillListBox.SelectedItem.ToString() != "")
                    textBox.Text = prcToKillListBox.SelectedItem.ToString();

            }
            if (prcToRunListBox.Focused || prcToRunButton.Focused)
            {

                if (prcToRunListBox.SelectedItems != null)
                {

                    prcToKillListBox.SelectedItems.Clear();
                    runOnStartListBox.SelectedItems.Clear();
                    runOnExitListBox.SelectedItems.Clear();

                }

                if (prcToRunListBox.SelectedItem != null && prcToRunListBox.SelectedItem.ToString() != "")
                    textBox.Text = prcToRunListBox.SelectedItem.ToString();

            }
            if (runOnStartListBox.Focused || runOnStartButton.Focused)
            {

                if (runOnStartListBox.SelectedItem != null)
                {

                    prcToKillListBox.SelectedItems.Clear();
                    prcToRunListBox.SelectedItems.Clear();
                    runOnExitListBox.SelectedItems.Clear();

                }

                if (runOnStartListBox.SelectedItem != null && runOnStartListBox.SelectedItem.ToString() != "")
                    textBox.Text = runOnStartListBox.SelectedItem.ToString();

            }
            if (runOnExitListBox.Focused || runOnExitButton.Focused)
            {

                if (runOnExitListBox.SelectedItems != null)
                {

                    prcToKillListBox.SelectedItems.Clear();
                    prcToRunListBox.SelectedItems.Clear();
                    runOnStartListBox.SelectedItems.Clear();

                }

                if (runOnExitListBox.SelectedItem != null && runOnExitListBox.SelectedItem.ToString() != "")
                    textBox.Text = runOnExitListBox.SelectedItem.ToString();

            }

            bool isListFocused = prcToKillListBox.Focused || prcToRunListBox.Focused || prcToKillButton.Focused || prcToRunButton.Focused
                || runOnStartListBox.Focused || runOnExitListBox.Focused || runOnStartButton.Focused || runOnExitButton.Focused;

            if (gameSelected != "" && isListFocused
                || gamesListBox.Focused || gamesButton.Focused)
            {

                if (sender is ListBox)
                    listNameSelected = (sender as ListBox).Name;
                else
                    listNameSelected = (sender as Button).Name.Substring(0, (sender as Button).Name.Length - 6) + "ListBox";

            }

            setLabelsColor();

        }

        //-- SWITCH AUTOCLEANING PREFERNCE --

        private void onAutocleaningChanged(object sender, EventArgs e)
        {

            data.settings["autoclean"] = autoclnCheckBox.Checked ? "true" : "false";

            serialize();

        }

        private void onAutoloadChanged(object sender, EventArgs e)
        {

            data.settings["autoload"] = autoloadCheckBox.Checked ? "true" : "false";

            serialize();

        }

        //-- SERIALIZE (SAVE) DATA --

        private void serialize()
        {

            string jsonSerialize = JsonSerializer.Serialize(data);

            if (!File.Exists("data.json") || File.ReadAllText("data.json").Length == 0) initializeData();

            File.WriteAllText("data.json", jsonSerialize);

        }

        //-- SWITCH LANGUAGE PREFERENCE --

        private void onLngChanged(object sender, EventArgs e)
        {

            data.settings["lng"] = lng[(sender as ComboBox).SelectedItem.ToString()];

            if (lngComboBox.Focused)
            {

                serialize();

                Application.Restart();
                Environment.Exit(0);

            }
        }

        //-- USE EXPLORER BROWSE WINDOW --

        private void onGamesBrowse(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog();

            string pattern = @"(?<=\\)[^\\/:*?<>|]+$";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection;

            if (result == DialogResult.OK)
            {

                if (listNameSelected != "gamesListBox")
                    textBox.Text = openFileDialog.FileName;

                else
                {

                    matchCollection = regex.Matches(openFileDialog.FileName);

                    textBox.Text = matchCollection[0].Value;

                }
            }
        }

        //-- HANDLE KEYBOARD KEYS PRESSING --

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Enter:
                    onItemAdded(textBox, null);
                    break;

                case Keys.Delete:
                    if (gamesListBox.Focused) onItemDeleted(gamesListBox, null);
                    if (prcToKillListBox.Focused) onItemDeleted(prcToKillListBox, null);
                    if (prcToRunListBox.Focused) onItemDeleted(prcToRunListBox, null);
                    if (runOnStartListBox.Focused) onItemDeleted(runOnStartListBox, null);
                    if (runOnExitListBox.Focused) onItemDeleted(runOnExitListBox, null);
                    break;

                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        //-- UPDATE LISTS OF PROCESSES RELATED TO A GAME --

        private void updatePrc(List<string> newPrcToKill, List<string> newPrcToRun, List<string> newRunOnStart, List<string> newRunOnExit)
        {

            prcToKill = new BindingList<String>(newPrcToKill);
            prcToRun = new BindingList<String>(newPrcToRun);
            runOnStart = new BindingList<string>(newRunOnStart);
            runOnExit = new BindingList<string>(newRunOnExit);

            prcToKillListBox.DataSource = prcToKill;
            prcToRunListBox.DataSource = prcToRun;
            runOnStartListBox.DataSource = runOnStart;
            runOnExitListBox.DataSource = runOnExit;

        }

        //-- SET BUTTONS 'ENABLED' PROPERTY --

        private void setEnableButtons(bool enable)
        {

            addItemButton.Enabled = enable;
            browseButton.Enabled = enable;

        }

        //-- SET COLOR THEME --

        private void onThemeChange(object sender, EventArgs e)
        {

            data.settings["dark_thm"] = darkThmCheckBox.Checked ? "true" : "false";

            serialize();

            if (darkThmCheckBox.Focused)
            {

                Application.Restart();
                Environment.Exit(0);

            }

        }

        //-- SET COLOR THEME --

        public void setTheme(Control.ControlCollection controls)
        {

            foreach (Control c in controls)
            {
                if (c is ListBox || c is TextBox || c is Button)
                {

                    c.BackColor = bkgColor;
                    c.ForeColor = frgColor;

                }
                else if (c is Label || c is CheckBox) c.ForeColor = frgColor;
                else if (c is Panel)
                {

                    setTheme(c.Controls);
                    c.BackColor = bkgColor;

                }
            }
        }

        //-- SET TITLE COLOR ACCORDING TO COLOR THEME --

        protected void setWindowTitleColor()
        {

            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);

        }

        //-- SET LABELS COLOR IF A LISTBOX IS BEING FOCUSED --

        private void setLabelsColor()
        {

            if (listNameSelected == "gamesListBox") gamesButton.ForeColor = colorAccent;
            else gamesButton.ForeColor = frgColor;

            if (listNameSelected == "prcToKillListBox") prcToKillButton.ForeColor = colorAccent;
            else prcToKillButton.ForeColor = frgColor;

            if (listNameSelected == "prcToRunListBox") prcToRunButton.ForeColor = colorAccent;
            else prcToRunButton.ForeColor = frgColor;

            if (listNameSelected == "runOnStartListBox") runOnStartButton.ForeColor = colorAccent;
            else runOnStartButton.ForeColor = frgColor;

            if (listNameSelected == "runOnExitListBox") runOnExitButton.ForeColor = colorAccent;
            else runOnExitButton.ForeColor = frgColor;

        }

        //-- INITIALIZE DATA --

        private void initializeData()
        {

            foreach (KeyValuePair<string, object> setting in dataSettings)
            {

                if (!data.settings.ContainsKey(setting.Key)) data.settings[setting.Key] = (string) setting.Value;

            }
        }

        //-- ACTIONS ON FORM CLOSE --

        private void onFormClose(object sender, FormClosedEventArgs e)
        {
            
            if (Process.GetProcessesByName("grayemoProcess").Length != 0)
            {

                foreach (Process process in Process.GetProcessesByName("grayemoProcess"))
                    process.Kill();

                Process.Start("grayemoProcess");

            }

            if (!showWelcomeForm && data.settings["welcome"] == "true")
            {

                data.settings["welcome"] = "false";

                serialize();

            }
        }
    }
}