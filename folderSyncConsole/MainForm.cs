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

        public static string leftFolderPath;
        public static string rightFolderPath;
        public FileSyncScopeFilter mainFilter = new FileSyncScopeFilter();
        FileSyncOptions mainOptions = new FileSyncOptions();
        private static int direction;
        private static List<string> expectedResult;
        List<string> forExFilter = new List<string>();
        List<string> forInFilter = new List<string>();
        private static string logFilePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), @"log.txt");

        
        

        private void leftFolderBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                leftFolderTextBox.Text = fileDialog.SelectedPath;
                leftFolderPath = ReturnPath(fileDialog.SelectedPath, leftFolderPath);
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
                rightFolderPath = ReturnPath(fileDialog.SelectedPath, rightFolderPath);
            }
            
        }

        private void analizeButton_Click(object sender, EventArgs e)
        {
           

            CompareFolders leftDifference = new CompareFolders(leftFolderPath, rightFolderPath);
            CompareFolders rightDifference = new CompareFolders(rightFolderPath, leftFolderPath);
            leftFolderDifferenceListBox.DataSource = null;
            rightFolderDifferenceListBox.DataSource = null;
            leftFolderDifferenceListBox.DataSource = leftDifference.Compare();
            rightFolderDifferenceListBox.DataSource = rightDifference.Compare();

        }

        private void doSyncButton_Click(object sender, EventArgs e)
        {

            direction = directionComboBox.SelectedIndex;
            DoSync doSync = new DoSync(leftFolderPath, rightFolderPath, mainFilter, mainOptions, direction);
            UnitTest test = new UnitTest(leftFolderPath, rightFolderPath, direction, expectedResult);
            //TODO: expected results doesn't work correct when some items added to filter
            expectedResult = test.GetExpectedResult(direction);
            doSync.Sync();
            UnitTest test2 = new UnitTest(leftFolderPath, rightFolderPath, direction, expectedResult);
            test2.Test(direction);
            List<string> forLog = doSync.LogToListBox();
            forLog.AddRange(test2.LogToListBox());
            actionsListBox.DataSource = forLog;
            ReaderWritter.Writelines(logFilePath, forLog);
            
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
