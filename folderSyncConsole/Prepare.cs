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
    public class Prepare
    {
        private static List<string> fileNames = new List<string>();
        private static string sourceFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\SourceFolder\";
        private static string destinationFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\DestinationFolder\";

        private static string copySource = Directory.GetCurrentDirectory() + @"\1\SourceFolder\";
        private static string copyDest = Directory.GetCurrentDirectory() + @"\1\DestinationFolder\";

        private List<string> Log = new List<string>();
        string logROW;
        List<string> expectedResult = new List<string>();
        
        public void PrepareForTesting()
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
