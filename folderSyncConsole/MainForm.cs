using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Synchronization.Files;
using Microsoft;
using System.Diagnostics;
using System.IO;

namespace Microsoft
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public string leftFolderPath;
        public string rightFolderPath;
        FileSyncScopeFilter mainFilter = new FileSyncScopeFilter();
        FileSyncOptions mainOptions = new FileSyncOptions();
        UnitTest test = new UnitTest();
        private int direction;
        

        private void leftFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                leftFolderTextBox.Text = fileDialog.SelectedPath;
                ReturnPath(fileDialog.SelectedPath, leftFolderPath);
            }
        }

        public string ReturnPath(string inPath, string path)
        {
           path = inPath;
            return path;
        }

        private void rightFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                rightFolderTextBox.Text = fileDialog.SelectedPath;
                ReturnPath(fileDialog.SelectedPath, rightFolderPath);
            }
        }

        private void analizeButton_Click(object sender, EventArgs e)
        {

        }

        private void doSyncButton_Click(object sender, EventArgs e)
        {
            //Added hardcoded pathes, must be removed after testing
            directionComboBox.SelectedIndex = 0;
            test.Prepare();
            leftFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\SourceFolder\";
            rightFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\DestinationFolder\";
            direction = directionComboBox.SelectedIndex;
            DoSync doSync = new DoSync(leftFolderPath, rightFolderPath, mainFilter, mainOptions, direction);
            doSync.Sync();
            string testId = "Test" + direction;
            test.Test(direction);
            test.PrintLog();
        }
    }
}
