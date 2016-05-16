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
        private static string sourceFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\SourceFolder\";
        private static string destinationFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\DestinationFolder\";

        private static string copySource = Directory.GetCurrentDirectory() + @"\1\SourceFolder\";
        private static string copyDest = Directory.GetCurrentDirectory() + @"\1\DestinationFolder\";

        //private static string sourceFile = Directory.GetCurrentDirectory() + @"\textFiles\source.txt";
        //private static string destFile = Directory.GetCurrentDirectory() + @"\textFiles\dest.txt";
        //private static string updatedFile = Directory.GetCurrentDirectory() + @"\textFiles\updated.txt";
        public UnitTest(string sourceFolder, string destinationFolder)
        {
            sourceFolderPath = sourceFolder;
            destinationFolderPath = destinationFolder;
        }

        private List<string> Log = new List<string>();
        string logROW;
        List<string> expectedResult = new List<string>();
        public void Prepare()
        {
            try
            {

                DeleteContent(sourceFolderPath);
                DeleteContent(destinationFolderPath);
                CopyContent(copySource, sourceFolderPath);
                CopyContent(copyDest, destinationFolderPath);

                logROW = "=========Prepare  PASSED successfully=========";
                AddToLog(logROW, Log);
                //expectedResult = getExpectedResult();

            }
            catch
            {
                logROW = "-------Prepare  FAILED-------";
                AddToLog(logROW, Log);
            }
        }


        private void DeleteContent(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        private void CopyContent(string copyPath, string targetPath)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(copyPath);
            FileInfo[] fi = di.GetFiles();
            foreach (FileInfo fiTemp in fi)
            {
                string sourceFile = System.IO.Path.Combine(copyPath, fiTemp.Name);
                string destFile = System.IO.Path.Combine(targetPath, fiTemp.Name);
                System.IO.File.Copy(sourceFile, destFile, true);
            }

        }

        private bool Check(string sourcePath, string destPath, string logRow, List<string> log)
        {
            bool check = false;
            
            foreach(string s in expectedResult)
            {
                string fileName = System.IO.Path.Combine(sourcePath, s);
                if (File.Exists(fileName))
                {
                    check = true;
                }
                else
                {
                    check = false;
                    logRow = "-------SyncLeft test FAILED-------";
                    AddToLog(logRow, log);
                    logRow = "File " + s + " failed";
                    AddToLog(logRow, log);
                    break;
                }

            }

            expectedResult = new List<string>();
            return check;
        }

        public List<string> getExpectedResult()
        {
            List<string> expectedResult = new List<string>();
            CompareFolders comp = new CompareFolders(destinationFolderPath, sourceFolderPath);
            IEnumerable<System.IO.FileInfo> list = comp.CreateListOfFiles(sourceFolderPath);
            List<string> differenceList = comp.Compare();
            foreach(System.IO.FileInfo v in list)
            {
                expectedResult.Add(v.Name);
            }
            expectedResult.AddRange(differenceList);

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
                logROW = "=========SyncLeft test PASSED successfully=========";
                AddToLog(logROW, Log);
            }
            else
            {
                logROW = "-------SyncLeft test FAILED-------";
                AddToLog(logROW, Log);
            }
        }

        private  void UpdateRight()
        {
            if (Check(destinationFolderPath, sourceFolderPath, logROW, Log))
            {
                logROW = "=========SyncRight test PASSED successfully=========";
                AddToLog(logROW, Log);
            }
            else
            {
                logROW = "-------SyncRight test FAILED-------";
                AddToLog(logROW, Log);
            }
        }


        private  void UpdateBoth()
        {

            if (Check(sourceFolderPath, destinationFolderPath, logROW, Log) && Check(destinationFolderPath, sourceFolderPath, logROW, Log))
            {
                logROW = "=========SyncBoth test PASSED successfully=========";
                AddToLog(logROW, Log);
            }
            
            else
            {
                logROW = "-------SyncBoth test FAILED-------";
                AddToLog(logROW, Log);
            }
         }


        private  void MirrorToLeft()
        {
            if (Check(destinationFolderPath, destinationFolderPath, logROW, Log))
            {
                logROW = "=========MirrorLeft test PASSED successfully=========";
                AddToLog(logROW, Log);
            }
            else
            {

                logROW = "-------MirrorLeft test FAILED-------";
                AddToLog(logROW, Log);
            }
        }

        private  void MirrorToRight()
        {

            if (Check(sourceFolderPath, sourceFolderPath, logROW, Log))
            {
                logROW = "=========MirrorRight test PASSED successfully=========";
                AddToLog(logROW, Log);
            }
            else
            {
                logROW = "-------MirrorRight test FAILED-------";
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

    }
}
