using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsoft
{
    public class UnitTest
    {
        private static List<string> fileNames = new List<string>();
        private static string sourceFolderPath;
        private static string destinationFolderPath;
        private static int direction;
        private static List<string> expectedResult;

        public UnitTest(string sourceFolder, string destinationFolder, int outDirection, List<string> outExpectedResult)
        {
            sourceFolderPath = sourceFolder;
            destinationFolderPath = destinationFolder;
            direction = outDirection;
            expectedResult = outExpectedResult;
        }

        private List<string> Log = new List<string>();
        string logROW;



        private bool Check(string sourcePath, string destPath, string logRow, List<string> log)
        {
            bool check = false;

            foreach (string s in expectedResult)
            {
                string fileName = System.IO.Path.Combine(sourcePath, s);
                if (File.Exists(fileName))
                {
                    check = true;
                }
                else
                {
                    check = false;
                    logROW = DateTime.Now + " Sync test FAILED";
                    AddToLog(logRow, log);
                    logROW = DateTime.Now + " File " + s + " failed";
                    AddToLog(logRow, log);
                    break;
                }

            }

            //expectedResult = new List<string>();
            return check;
        }

        public List<string> GetExpectedResult(int direction)
        {
            List<string> expectedResult = new List<string>();
            CompareFolders comp = new CompareFolders(destinationFolderPath, sourceFolderPath);
            if (direction == 3)
            {
                IEnumerable<System.IO.FileInfo> list = comp.CreateListOfFiles(destinationFolderPath);
                List<string> differenceList = comp.Compare();
                foreach (System.IO.FileInfo v in list)
                {
                    expectedResult.Add(v.Name);
                }
                if ((direction >= 0) && (direction <= 2))
                {
                    expectedResult.AddRange(differenceList);
                }
            }
            else
            {
                IEnumerable<System.IO.FileInfo> list = comp.CreateListOfFiles(sourceFolderPath);
                List<string> differenceList = comp.Compare();
                foreach (System.IO.FileInfo v in list)
                {
                    expectedResult.Add(v.Name);
                }
                if ((direction >= 0) && (direction <= 2))
                {
                    expectedResult.AddRange(differenceList);
                }
            }
            return expectedResult;
        }
        public void Test(int direction)
        {
            switch (direction)
            {
                case 0:
                    UpdateLeft();
                    break;
                case 1:
                    UpdateRight();
                    break;
                case 2:
                    UpdateBoth();
                    break;
                case 3:
                    MirrorToLeft();
                    break;
                case 4:
                    MirrorToRight();
                    break;
            }
        }

        private void UpdateLeft()
        {

            if (Check(sourceFolderPath, destinationFolderPath, logROW, Log))
            {
                logROW = DateTime.Now + " Left Folder updated successfully";
                AddToLog(logROW, Log);
            }
            else
            {
                logROW = DateTime.Now + " Left Folder update FAILED";
                AddToLog(logROW, Log);
            }
        }

        private void UpdateRight()
        {
            if (Check(destinationFolderPath, sourceFolderPath, logROW, Log))
            {
                logROW = DateTime.Now + " Right Folder updated successfully";
                AddToLog(logROW, Log);
            }
            else
            {
                logROW = DateTime.Now + " Right Folder update FAILED";
                AddToLog(logROW, Log);
            }
        }


        private void UpdateBoth()
        {

            if (Check(sourceFolderPath, destinationFolderPath, logROW, Log) && Check(destinationFolderPath, sourceFolderPath, logROW, Log))
            {
                logROW = DateTime.Now + " Both Folders updated successfully";
                AddToLog(logROW, Log);
            }

            else
            {
                logROW = DateTime.Now + " Both Folders update FAILED";
                AddToLog(logROW, Log);
            }
        }


        private void MirrorToLeft()
        {
            if (Check(sourceFolderPath, sourceFolderPath, logROW, Log))
            {
                logROW = DateTime.Now + " MirrorLeft updated successfully";
                AddToLog(logROW, Log);
            }
            else
            {

                logROW = DateTime.Now + " MirrorLeft update FAILED";
                AddToLog(logROW, Log);
            }
        }

        private void MirrorToRight()
        {

            if (Check(sourceFolderPath, sourceFolderPath, logROW, Log))
            {
                logROW = DateTime.Now + " MirrorRight updated successfully";
                AddToLog(logROW, Log);
            }
            else
            {
                logROW = DateTime.Now + " MirrorRight update FAILED";
                AddToLog(logROW, Log);
            }
        }

        private void AddToLog(string logRow, List<string> logList)
        {
            logList.Add(logRow);
        }

        public void PrintLog()
        {
            var message = string.Join(Environment.NewLine, Log);
            MessageBox.Show(message);
            //message = default(string);
        }

        public List<string> LogToListBox()
        {
            return Log;
        }

    }
}
