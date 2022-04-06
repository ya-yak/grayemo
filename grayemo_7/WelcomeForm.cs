using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace grayemo
{
    public partial class WelcomeForm : Form
    {

        const int lastPage = 9;

        int page = 1;

        Dictionary<int, Panel> panels = new Dictionary<int, Panel>();

        [DllImport("dwmapi.dll")]

        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]

        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font captionFont, descrFont;

        //-- FORM INITIALIZATION --

        public WelcomeForm()
        {

            InitializeComponent();

            byte[] fontData = Properties.Resources.Andika_Regular;

            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);

            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            uint dummy = 0;

            fonts.AddMemoryFont(fontPtr, Properties.Resources.Andika_Regular.Length);

            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.Andika_Regular.Length, IntPtr.Zero, ref dummy);

            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            captionFont = new Font(fonts.Families[0], 16.5F);
            descrFont = new Font(fonts.Families[0], 8.25F);

            panels.Add(1, panel1);
            panels.Add(2, panel2);
            panels.Add(3, panel3);
            panels.Add(4, panel4);
            panels.Add(5, panel5);
            panels.Add(6, panel6);
            panels.Add(7, panel7);
            panels.Add(8, panel8);
            panels.Add(9, panel9);

            string pattern = @"^\D+";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection;

            foreach (KeyValuePair<int, Panel> p in panels)
            {

                foreach (Control c in p.Value.Controls)
                {

                    matchCollection = regex.Matches(c.Name);

                    if (matchCollection[0].Value == "captionLabel") c.Font = captionFont;
                    if (matchCollection[0].Value == "descrLabel") c.Font = descrFont;

                }    
            }

                setTheme(Controls);

            if (Form1.darkTheme) setWindowTitleColor();

        }

        //-- TURN FORWARD IF NEXT BUTTON CLICKED --

        private void onNextButtonClicked(object sender, EventArgs e)
        {

            panels[page].Visible = false;

            page++;

            panels[page].Visible = true;

            if (page == lastPage) nextButton.Enabled = false;
            if (page == 2) backButton.Enabled = true;

        }

        //-- TURN BACK IF BACK BUTTON CLICKED --

        private void onBackButtonClicked(object sender, EventArgs e)
        {

            panels[page].Visible = false;

            page--;

            panels[page].Visible = true;

            if (page == 1) backButton.Enabled = false;
            if (page == lastPage - 1) nextButton.Enabled = true;

        }

        //-- SET COLOR THEME --

        public void setTheme(Control.ControlCollection controls)
        {

            foreach (Control c in controls)
            {
                if (c is ListBox || c is TextBox || c is Button)
                {

                    c.BackColor = Form1.bkgColor;
                    c.ForeColor = Form1.frgColor;

                }
                else if (c is Label || c is CheckBox) c.ForeColor = Form1.frgColor;
                else if (c is Panel)
                {

                    setTheme(c.Controls);
                    c.BackColor = Form1.bkgColor;

                }
            }
        }

        //-- SET TITLE COLOR ACCORDING TO COLOR THEME --

        protected void setWindowTitleColor()
        {

            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);

        }

        //-- DO NOT SHOW WELCOME AGAIN IF FORM CLOSED --
        
        private void onFormClosed(object sender, FormClosedEventArgs e)
        {

            if (Form.ActiveForm == this) Form1.showWelcomeForm = false;

        }
    }
}
