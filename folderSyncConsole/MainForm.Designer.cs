namespace Microsoft
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.actionsListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rightFolderDifferenceListBox = new System.Windows.Forms.ListBox();
            this.leftFolderDifferenceListBox = new System.Windows.Forms.ListBox();
            this.syncSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.directionComboBox = new System.Windows.Forms.ComboBox();
            this.doSyncButton = new System.Windows.Forms.Button();
            this.analizeButton = new System.Windows.Forms.Button();
            this.rightFolderBrowseButton = new System.Windows.Forms.Button();
            this.rightFolderTextBox = new System.Windows.Forms.TextBox();
            this.leftFolderBrowseButton = new System.Windows.Forms.Button();
            this.leftFolderTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.syncSettingsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1430, 592);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.actionsListBox);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.syncSettingsGroupBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1422, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sync Options";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 466);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Actions";
            // 
            // actionsListBox
            // 
            this.actionsListBox.FormattingEnabled = true;
            this.actionsListBox.Location = new System.Drawing.Point(7, 479);
            this.actionsListBox.Name = "actionsListBox";
            this.actionsListBox.Size = new System.Drawing.Size(1409, 82);
            this.actionsListBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rightFolderDifferenceListBox);
            this.groupBox2.Controls.Add(this.leftFolderDifferenceListBox);
            this.groupBox2.Location = new System.Drawing.Point(7, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1409, 260);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Folders Difference";
            // 
            // rightFolderDifferenceListBox
            // 
            this.rightFolderDifferenceListBox.FormattingEnabled = true;
            this.rightFolderDifferenceListBox.Location = new System.Drawing.Point(727, 20);
            this.rightFolderDifferenceListBox.Name = "rightFolderDifferenceListBox";
            this.rightFolderDifferenceListBox.Size = new System.Drawing.Size(676, 225);
            this.rightFolderDifferenceListBox.TabIndex = 0;
            // 
            // leftFolderDifferenceListBox
            // 
            this.leftFolderDifferenceListBox.FormattingEnabled = true;
            this.leftFolderDifferenceListBox.Location = new System.Drawing.Point(7, 19);
            this.leftFolderDifferenceListBox.Name = "leftFolderDifferenceListBox";
            this.leftFolderDifferenceListBox.Size = new System.Drawing.Size(676, 225);
            this.leftFolderDifferenceListBox.TabIndex = 0;
            // 
            // syncSettingsGroupBox
            // 
            this.syncSettingsGroupBox.Controls.Add(this.directionComboBox);
            this.syncSettingsGroupBox.Controls.Add(this.doSyncButton);
            this.syncSettingsGroupBox.Controls.Add(this.analizeButton);
            this.syncSettingsGroupBox.Controls.Add(this.rightFolderBrowseButton);
            this.syncSettingsGroupBox.Controls.Add(this.rightFolderTextBox);
            this.syncSettingsGroupBox.Controls.Add(this.leftFolderBrowseButton);
            this.syncSettingsGroupBox.Controls.Add(this.leftFolderTextBox);
            this.syncSettingsGroupBox.Location = new System.Drawing.Point(7, 7);
            this.syncSettingsGroupBox.Name = "syncSettingsGroupBox";
            this.syncSettingsGroupBox.Size = new System.Drawing.Size(1409, 186);
            this.syncSettingsGroupBox.TabIndex = 0;
            this.syncSettingsGroupBox.TabStop = false;
            this.syncSettingsGroupBox.Text = "SyncSettings";
            // 
            // directionComboBox
            // 
            this.directionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.directionComboBox.FormattingEnabled = true;
            this.directionComboBox.Items.AddRange(new object[] {
            "<<Update Left",
            ">>Update Right",
            "<>Update Both",
            "<=Mirror To Left",
            "=>Mirror To Right"});
            this.directionComboBox.Location = new System.Drawing.Point(608, 60);
            this.directionComboBox.Name = "directionComboBox";
            this.directionComboBox.Size = new System.Drawing.Size(225, 21);
            this.directionComboBox.TabIndex = 6;
            // 
            // doSyncButton
            // 
            this.doSyncButton.Location = new System.Drawing.Point(608, 145);
            this.doSyncButton.Name = "doSyncButton";
            this.doSyncButton.Size = new System.Drawing.Size(225, 23);
            this.doSyncButton.TabIndex = 5;
            this.doSyncButton.Text = "Sync Folders";
            this.doSyncButton.UseVisualStyleBackColor = true;
            this.doSyncButton.Click += new System.EventHandler(this.doSyncButton_Click);
            // 
            // analizeButton
            // 
            this.analizeButton.Location = new System.Drawing.Point(608, 115);
            this.analizeButton.Name = "analizeButton";
            this.analizeButton.Size = new System.Drawing.Size(225, 23);
            this.analizeButton.TabIndex = 4;
            this.analizeButton.Text = "Analize";
            this.analizeButton.UseVisualStyleBackColor = true;
            this.analizeButton.Click += new System.EventHandler(this.analizeButton_Click);
            // 
            // rightFolderBrowseButton
            // 
            this.rightFolderBrowseButton.Location = new System.Drawing.Point(1334, 16);
            this.rightFolderBrowseButton.Name = "rightFolderBrowseButton";
            this.rightFolderBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.rightFolderBrowseButton.TabIndex = 3;
            this.rightFolderBrowseButton.Text = "Browse";
            this.rightFolderBrowseButton.UseVisualStyleBackColor = true;
            this.rightFolderBrowseButton.Click += new System.EventHandler(this.rightFolderBrowseButton_Click);
            // 
            // rightFolderTextBox
            // 
            this.rightFolderTextBox.Location = new System.Drawing.Point(727, 19);
            this.rightFolderTextBox.Name = "rightFolderTextBox";
            this.rightFolderTextBox.Size = new System.Drawing.Size(601, 20);
            this.rightFolderTextBox.TabIndex = 2;
            // 
            // leftFolderBrowseButton
            // 
            this.leftFolderBrowseButton.Location = new System.Drawing.Point(608, 19);
            this.leftFolderBrowseButton.Name = "leftFolderBrowseButton";
            this.leftFolderBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.leftFolderBrowseButton.TabIndex = 1;
            this.leftFolderBrowseButton.Text = "Browse";
            this.leftFolderBrowseButton.UseVisualStyleBackColor = true;
            this.leftFolderBrowseButton.Click += new System.EventHandler(this.leftFolderBrowseButton_Click);
            // 
            // leftFolderTextBox
            // 
            this.leftFolderTextBox.Location = new System.Drawing.Point(7, 19);
            this.leftFolderTextBox.Name = "leftFolderTextBox";
            this.leftFolderTextBox.Size = new System.Drawing.Size(595, 20);
            this.leftFolderTextBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1422, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Filters";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 616);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.syncSettingsGroupBox.ResumeLayout(false);
            this.syncSettingsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox actionsListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox rightFolderDifferenceListBox;
        private System.Windows.Forms.ListBox leftFolderDifferenceListBox;
        private System.Windows.Forms.GroupBox syncSettingsGroupBox;
        private System.Windows.Forms.ComboBox directionComboBox;
        private System.Windows.Forms.Button doSyncButton;
        private System.Windows.Forms.Button analizeButton;
        private System.Windows.Forms.Button rightFolderBrowseButton;
        private System.Windows.Forms.TextBox rightFolderTextBox;
        private System.Windows.Forms.Button leftFolderBrowseButton;
        private System.Windows.Forms.TextBox leftFolderTextBox;
        private System.Windows.Forms.TabPage tabPage2;
    }
}