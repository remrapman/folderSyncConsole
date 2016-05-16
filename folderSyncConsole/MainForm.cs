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
        public static string leftFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\SourceFolder\";
        public static string rightFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\DestinationFolder\";
        FileSyncScopeFilter mainFilter = new FileSyncScopeFilter();
        FileSyncOptions mainOptions = new FileSyncOptions();
        UnitTest test = new UnitTest(leftFolderPath, rightFolderPath);
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
            //TO DO: Added hardcoded pathes, must be removed after testing
            test.Prepare();

            CompareFolders leftDifference = new CompareFolders(leftFolderPath, rightFolderPath);
            CompareFolders rightDifference = new CompareFolders(rightFolderPath, leftFolderPath);
            leftFolderDifferenceListBox.DataSource = null;
            rightFolderDifferenceListBox.DataSource = null;
            leftFolderDifferenceListBox.DataSource = leftDifference.Compare();
            rightFolderDifferenceListBox.DataSource = rightDifference.Compare();

        }

        private void doSyncButton_Click(object sender, EventArgs e)
        {
            //TO DO: Added hardcoded pathes, must be removed after testing
            test.Prepare();
            direction = directionComboBox.SelectedIndex;
            DoSync doSync = new DoSync(leftFolderPath, rightFolderPath, mainFilter, mainOptions, direction);
            
            //TO DO: Add direction to getExpectedResult
            test.getExpectedResult();
            doSync.Sync();
            string testId = "Test" + direction;
            test.Test(direction);
            test.PrintLog();
        }
    }
}
