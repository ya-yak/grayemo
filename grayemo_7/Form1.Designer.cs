namespace grayemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.addItemButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.prcToKillListBox = new System.Windows.Forms.ListBox();
            this.autoclnCheckBox = new System.Windows.Forms.CheckBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.lngComboBox = new System.Windows.Forms.ComboBox();
            this.darkThmCheckBox = new System.Windows.Forms.CheckBox();
            this.panel = new System.Windows.Forms.Panel();
            this.helpButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.runOnExitPanel = new System.Windows.Forms.Panel();
            this.runOnExitButton = new System.Windows.Forms.Button();
            this.runOnExitListBox = new System.Windows.Forms.ListBox();
            this.runOnStartPanel = new System.Windows.Forms.Panel();
            this.runOnStartButton = new System.Windows.Forms.Button();
            this.runOnStartListBox = new System.Windows.Forms.ListBox();
            this.prcToKillPanel = new System.Windows.Forms.Panel();
            this.prcToKillButton = new System.Windows.Forms.Button();
            this.prcToRunPanel = new System.Windows.Forms.Panel();
            this.prcToRunButton = new System.Windows.Forms.Button();
            this.prcToRunListBox = new System.Windows.Forms.ListBox();
            this.autoloadCheckBox = new System.Windows.Forms.CheckBox();
            this.gamesListBox = new System.Windows.Forms.ListBox();
            this.gamesButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.runOnExitPanel.SuspendLayout();
            this.runOnStartPanel.SuspendLayout();
            this.prcToKillPanel.SuspendLayout();
            this.prcToRunPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addItemButton
            // 
            resources.ApplyResources(this.addItemButton, "addItemButton");
            this.addItemButton.BackColor = System.Drawing.Color.White;
            this.addItemButton.ForeColor = System.Drawing.Color.Black;
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.UseVisualStyleBackColor = false;
            this.addItemButton.Click += new System.EventHandler(this.onItemAdded);
            // 
            // textBox
            // 
            resources.ApplyResources(this.textBox, "textBox");
            this.textBox.BackColor = System.Drawing.Color.White;
            this.textBox.Name = "textBox";
            // 
            // prcToKillListBox
            // 
            resources.ApplyResources(this.prcToKillListBox, "prcToKillListBox");
            this.prcToKillListBox.BackColor = System.Drawing.Color.White;
            this.prcToKillListBox.ForeColor = System.Drawing.Color.Black;
            this.prcToKillListBox.FormattingEnabled = true;
            this.prcToKillListBox.Name = "prcToKillListBox";
            this.prcToKillListBox.Click += new System.EventHandler(this.onItemChanged);
            this.prcToKillListBox.DoubleClick += new System.EventHandler(this.onItemDesselected);
            // 
            // autoclnCheckBox
            // 
            resources.ApplyResources(this.autoclnCheckBox, "autoclnCheckBox");
            this.autoclnCheckBox.ForeColor = System.Drawing.Color.Black;
            this.autoclnCheckBox.Name = "autoclnCheckBox";
            this.autoclnCheckBox.UseVisualStyleBackColor = true;
            this.autoclnCheckBox.Click += new System.EventHandler(this.onAutocleaningChanged);
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.BackColor = System.Drawing.Color.White;
            this.removeButton.ForeColor = System.Drawing.Color.Black;
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.onItemDeleted);
            // 
            // lngComboBox
            // 
            resources.ApplyResources(this.lngComboBox, "lngComboBox");
            this.lngComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lngComboBox.FormattingEnabled = true;
            this.lngComboBox.Name = "lngComboBox";
            this.lngComboBox.SelectedIndexChanged += new System.EventHandler(this.onLngChanged);
            // 
            // darkThmCheckBox
            // 
            resources.ApplyResources(this.darkThmCheckBox, "darkThmCheckBox");
            this.darkThmCheckBox.ForeColor = System.Drawing.Color.Black;
            this.darkThmCheckBox.Name = "darkThmCheckBox";
            this.darkThmCheckBox.UseVisualStyleBackColor = true;
            this.darkThmCheckBox.Click += new System.EventHandler(this.onThemeChange);
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.BackColor = System.Drawing.Color.White;
            this.panel.Controls.Add(this.helpButton);
            this.panel.Controls.Add(this.tableLayoutPanel);
            this.panel.Controls.Add(this.autoloadCheckBox);
            this.panel.Controls.Add(this.autoclnCheckBox);
            this.panel.Controls.Add(this.lngComboBox);
            this.panel.Controls.Add(this.gamesListBox);
            this.panel.Controls.Add(this.gamesButton);
            this.panel.Controls.Add(this.browseButton);
            this.panel.Controls.Add(this.darkThmCheckBox);
            this.panel.Controls.Add(this.addItemButton);
            this.panel.Controls.Add(this.removeButton);
            this.panel.Controls.Add(this.textBox);
            this.panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel.Name = "panel";
            // 
            // helpButton
            // 
            resources.ApplyResources(this.helpButton, "helpButton");
            this.helpButton.BackColor = System.Drawing.Color.White;
            this.helpButton.ForeColor = System.Drawing.Color.Black;
            this.helpButton.Image = global::grayemo.Properties.Resources.g7310__2_;
            this.helpButton.Name = "helpButton";
            this.helpButton.UseVisualStyleBackColor = false;
            this.helpButton.Click += new System.EventHandler(this.onHelpRequested);
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.runOnExitPanel, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.runOnStartPanel, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.prcToKillPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.prcToRunPanel, 0, 1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // runOnExitPanel
            // 
            resources.ApplyResources(this.runOnExitPanel, "runOnExitPanel");
            this.runOnExitPanel.Controls.Add(this.runOnExitButton);
            this.runOnExitPanel.Controls.Add(this.runOnExitListBox);
            this.runOnExitPanel.Name = "runOnExitPanel";
            // 
            // runOnExitButton
            // 
            resources.ApplyResources(this.runOnExitButton, "runOnExitButton");
            this.runOnExitButton.BackColor = System.Drawing.Color.Transparent;
            this.runOnExitButton.FlatAppearance.BorderSize = 0;
            this.runOnExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.runOnExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.runOnExitButton.Name = "runOnExitButton";
            this.runOnExitButton.UseVisualStyleBackColor = false;
            this.runOnExitButton.Click += new System.EventHandler(this.onItemChanged);
            // 
            // runOnExitListBox
            // 
            resources.ApplyResources(this.runOnExitListBox, "runOnExitListBox");
            this.runOnExitListBox.BackColor = System.Drawing.Color.White;
            this.runOnExitListBox.ForeColor = System.Drawing.Color.Black;
            this.runOnExitListBox.FormattingEnabled = true;
            this.runOnExitListBox.Name = "runOnExitListBox";
            this.runOnExitListBox.Click += new System.EventHandler(this.onItemChanged);
            this.runOnExitListBox.DoubleClick += new System.EventHandler(this.onItemDesselected);
            // 
            // runOnStartPanel
            // 
            resources.ApplyResources(this.runOnStartPanel, "runOnStartPanel");
            this.runOnStartPanel.Controls.Add(this.runOnStartButton);
            this.runOnStartPanel.Controls.Add(this.runOnStartListBox);
            this.runOnStartPanel.Name = "runOnStartPanel";
            // 
            // runOnStartButton
            // 
            resources.ApplyResources(this.runOnStartButton, "runOnStartButton");
            this.runOnStartButton.BackColor = System.Drawing.Color.Transparent;
            this.runOnStartButton.FlatAppearance.BorderSize = 0;
            this.runOnStartButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.runOnStartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.runOnStartButton.Name = "runOnStartButton";
            this.runOnStartButton.UseVisualStyleBackColor = false;
            this.runOnStartButton.Click += new System.EventHandler(this.onItemChanged);
            // 
            // runOnStartListBox
            // 
            resources.ApplyResources(this.runOnStartListBox, "runOnStartListBox");
            this.runOnStartListBox.BackColor = System.Drawing.Color.White;
            this.runOnStartListBox.ForeColor = System.Drawing.Color.Black;
            this.runOnStartListBox.FormattingEnabled = true;
            this.runOnStartListBox.Name = "runOnStartListBox";
            this.runOnStartListBox.Click += new System.EventHandler(this.onItemChanged);
            this.runOnStartListBox.DoubleClick += new System.EventHandler(this.onItemDesselected);
            // 
            // prcToKillPanel
            // 
            resources.ApplyResources(this.prcToKillPanel, "prcToKillPanel");
            this.prcToKillPanel.Controls.Add(this.prcToKillButton);
            this.prcToKillPanel.Controls.Add(this.prcToKillListBox);
            this.prcToKillPanel.Name = "prcToKillPanel";
            // 
            // prcToKillButton
            // 
            resources.ApplyResources(this.prcToKillButton, "prcToKillButton");
            this.prcToKillButton.BackColor = System.Drawing.Color.Transparent;
            this.prcToKillButton.FlatAppearance.BorderSize = 0;
            this.prcToKillButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.prcToKillButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.prcToKillButton.Name = "prcToKillButton";
            this.prcToKillButton.UseVisualStyleBackColor = false;
            this.prcToKillButton.Click += new System.EventHandler(this.onItemChanged);
            // 
            // prcToRunPanel
            // 
            resources.ApplyResources(this.prcToRunPanel, "prcToRunPanel");
            this.prcToRunPanel.Controls.Add(this.prcToRunButton);
            this.prcToRunPanel.Controls.Add(this.prcToRunListBox);
            this.prcToRunPanel.Name = "prcToRunPanel";
            // 
            // prcToRunButton
            // 
            resources.ApplyResources(this.prcToRunButton, "prcToRunButton");
            this.prcToRunButton.BackColor = System.Drawing.Color.Transparent;
            this.prcToRunButton.FlatAppearance.BorderSize = 0;
            this.prcToRunButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.prcToRunButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.prcToRunButton.Name = "prcToRunButton";
            this.prcToRunButton.UseVisualStyleBackColor = false;
            this.prcToRunButton.Click += new System.EventHandler(this.onItemChanged);
            // 
            // prcToRunListBox
            // 
            resources.ApplyResources(this.prcToRunListBox, "prcToRunListBox");
            this.prcToRunListBox.BackColor = System.Drawing.Color.White;
            this.prcToRunListBox.ForeColor = System.Drawing.Color.Black;
            this.prcToRunListBox.FormattingEnabled = true;
            this.prcToRunListBox.Name = "prcToRunListBox";
            this.prcToRunListBox.Click += new System.EventHandler(this.onItemChanged);
            this.prcToRunListBox.DoubleClick += new System.EventHandler(this.onItemDesselected);
            // 
            // autoloadCheckBox
            // 
            resources.ApplyResources(this.autoloadCheckBox, "autoloadCheckBox");
            this.autoloadCheckBox.ForeColor = System.Drawing.Color.Black;
            this.autoloadCheckBox.Name = "autoloadCheckBox";
            this.autoloadCheckBox.UseVisualStyleBackColor = true;
            this.autoloadCheckBox.Click += new System.EventHandler(this.onAutoloadChanged);
            // 
            // gamesListBox
            // 
            resources.ApplyResources(this.gamesListBox, "gamesListBox");
            this.gamesListBox.BackColor = System.Drawing.Color.White;
            this.gamesListBox.ForeColor = System.Drawing.Color.Black;
            this.gamesListBox.FormattingEnabled = true;
            this.gamesListBox.Name = "gamesListBox";
            this.gamesListBox.Click += new System.EventHandler(this.onItemChanged);
            this.gamesListBox.DoubleClick += new System.EventHandler(this.onItemDesselected);
            // 
            // gamesButton
            // 
            resources.ApplyResources(this.gamesButton, "gamesButton");
            this.gamesButton.BackColor = System.Drawing.Color.Transparent;
            this.gamesButton.FlatAppearance.BorderSize = 0;
            this.gamesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.gamesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.gamesButton.Name = "gamesButton";
            this.gamesButton.UseVisualStyleBackColor = false;
            this.gamesButton.Click += new System.EventHandler(this.onItemChanged);
            // 
            // browseButton
            // 
            resources.ApplyResources(this.browseButton, "browseButton");
            this.browseButton.BackColor = System.Drawing.Color.White;
            this.browseButton.ForeColor = System.Drawing.Color.Black;
            this.browseButton.Name = "browseButton";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.onGamesBrowse);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel);
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onFormClose);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.runOnExitPanel.ResumeLayout(false);
            this.runOnStartPanel.ResumeLayout(false);
            this.prcToKillPanel.ResumeLayout(false);
            this.prcToRunPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox prcToKillListBox;
        private System.Windows.Forms.CheckBox autoclnCheckBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.ComboBox lngComboBox;
        private System.Windows.Forms.CheckBox darkThmCheckBox;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ListBox prcToRunListBox;
        private System.Windows.Forms.ListBox gamesListBox;
        private System.Windows.Forms.Button gamesButton;
        private System.Windows.Forms.Button prcToRunButton;
        private System.Windows.Forms.Button prcToKillButton;
        private System.Windows.Forms.ListBox runOnExitListBox;
        private System.Windows.Forms.Button runOnExitButton;
        private System.Windows.Forms.Button runOnStartButton;
        private CheckBox autoloadCheckBox;
        private ListBox runOnStartListBox;
        private TableLayoutPanel tableLayoutPanel;
        private Panel prcToKillPanel;
        private Panel runOnExitPanel;
        private Panel runOnStartPanel;
        private Panel prcToRunPanel;
        private Button helpButton;
    }
}

