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
        //TO DO: Added hardcoded pathes, must be removed after testing
        public static string leftFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\SourceFolder\";
        public static string rightFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\DestinationFolder\";
        public FileSyncScopeFilter mainFilter = new FileSyncScopeFilter();
        FileSyncOptions mainOptions = new FileSyncOptions();
        private static int direction;
        private static List<string> expectedResult;
        UnitTest test = new UnitTest(leftFolderPath, rightFolderPath, direction, expectedResult);
        Prepare pre = new Prepare();
        List<string> forExFilter = new List<string>();
        List<string> forInFilter = new List<string>();

        
        

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
           
            pre.PrepareForTesting();

            CompareFolders leftDifference = new CompareFolders(leftFolderPath, rightFolderPath);
            CompareFolders rightDifference = new CompareFolders(rightFolderPath, leftFolderPath);
            leftFolderDifferenceListBox.DataSource = null;
            rightFolderDifferenceListBox.DataSource = null;
            leftFolderDifferenceListBox.DataSource = leftDifference.Compare();
            rightFolderDifferenceListBox.DataSource = rightDifference.Compare();

        }

        private void doSyncButton_Click(object sender, EventArgs e)
        {

            pre.PrepareForTesting();
            direction = directionComboBox.SelectedIndex;
            DoSync doSync = new DoSync(leftFolderPath, rightFolderPath, mainFilter, mainOptions, direction);
            
            //TO DO: Remove parameter "direction" from GetExpectedResult
            //ICollection<string> inList = mainFilter.FileNameIncludes;
            //ICollection<string> exList = mainFilter.FileNameIncludes;
            expectedResult = test.GetExpectedResult(direction);
            doSync.Sync();
            //TO DO: why i create testId?
            string testId = "Test" + direction;
            UnitTest test2 = new UnitTest(leftFolderPath, rightFolderPath, direction, expectedResult);
            test2.Test(direction);
            List<string> forLog = doSync.LogToListBox();
            forLog.AddRange(test2.LogToListBox());
            actionsListBox.DataSource = forLog;
            
            //actionsListBox.DataSource = doSync.LogToListBox();
            //actionsListBox.DataSource = test2.LogToListBox();
            
        }

        private void includeFilterAddItemButton_Click(object sender, EventArgs e)
        {
            mainFilter.FileNameIncludes.Add(includeFilterTextBox.Text);
            forInFilter = AddItemToFilter(forInFilter, includeFilterTextBox.Text);
            includeFilterListBox.DataSource = null;
            includeFilterListBox.DataSource = forInFilter;
            includeFilterTextBox.Clear();
        }

        private void includeFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            includeFilterAddItemButton.Enabled = !String.IsNullOrEmpty(includeFilterTextBox.Text);
        }

        private List<string> AddItemToFilter(List<string> inFilter, string item)
        {
            inFilter.Add(item);
            return inFilter;
        }

        private void excludeFilterAddItemButton_Click(object sender, EventArgs e)
        {
            mainFilter.FileNameExcludes.Add(excludeFilterTextBox.Text);
            forExFilter = AddItemToFilter(forExFilter, excludeFilterTextBox.Text);
            excludeFilterListBox.DataSource = null;
            excludeFilterListBox.DataSource = forExFilter;
            excludeFilterTextBox.Clear();
        }

        private void excludeFilterTextBox_TextChanged(object sender, EventArgs e)
        {
            excludeFilterAddItemButton.Enabled = !String.IsNullOrEmpty(excludeFilterTextBox.Text);
        }
    }
}
