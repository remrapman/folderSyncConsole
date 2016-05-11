using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace folderSyncConsole
{
    public class UnitTest
    {
        private static List<string> fileNames = new List<string>();
        private static string sourceFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\SourceFolder\";
        private static string destinationFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\DestinationFolder\";

        private static string copySource = Directory.GetCurrentDirectory() + @"\1\SourceFolder\";
        private static string copyDest = Directory.GetCurrentDirectory() + @"\1\DestinationFolder\";

        private static string sourceFile = Directory.GetCurrentDirectory() + @"\textFiles\source.txt";
        private static string destFile = Directory.GetCurrentDirectory() + @"\textFiles\dest.txt";
        private static string updatedFile = Directory.GetCurrentDirectory() + @"\textFiles\updated.txt";

        public void Prepare()
        {
            try
            {

                DeleteContent(sourceFolderPath);
                DeleteContent(destinationFolderPath);
                CopyContent(copySource, sourceFolderPath);
                CopyContent(copyDest, destinationFolderPath);

                Console.WriteLine("=========Prepare  PASSED successfully=========");
            }
            catch
            {

                Console.WriteLine("-------Prepare  FAILED-------");
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

        private static bool Check(string filePath, string folderPath, List<string> list)
        {
            bool check = false;
            ReaderWritter.Readlines(filePath, fileNames);

            for (int i = 0; i < fileNames.Count; i++)
            {
                string fileName = System.IO.Path.Combine(folderPath, fileNames[i]);

                //TO DO: Need fix to filenames with "–" symbol. When it chenged to "-" works fine.

                if (File.Exists(fileName))
                {
                    check = true;
                }
                else
                {
                    check = false;
                    break;
                }

            }
            fileNames = new List<string>();
            return check;


        }

        public static void UpdateLeft()
        {

            if (Check(updatedFile, sourceFolderPath, fileNames))
            {
                Console.WriteLine("=========SyncLeft test PASSED successfully=========");
            }
            else
            {
                Console.WriteLine("-------SyncLeft test FAILED-------");
            }
        }

        public static void UpdateRight()
        {
            if (Check(updatedFile, destinationFolderPath, fileNames))
            {
                Console.WriteLine("=========SyncRight test PASSED successfully=========");
            }
            else
            {
                Console.WriteLine("-------SyncRight test FAILED-------");
            }
        }

        
        public static void UpdateBoth()
        {

            if ((Check(updatedFile, sourceFolderPath, fileNames)) && Check(updatedFile, destinationFolderPath, fileNames))
            {
                Console.WriteLine("=========SyncBoth test PASSED successfully=========");
            }
            
            else
            {
                Console.WriteLine("-------SyncBoth test FAILED-------");
            }
         }


        public static void MirrorToLeft()
        {
            if (Check(destFile, sourceFolderPath, fileNames))
            {

                Console.WriteLine("=========MirrorLeft test PASSED successfully=========");
            }
            else
            {


                Console.WriteLine("-------MirrorLeft test FAILED-------");

            }
        }

        public static void MirrorToRight()
        {

            if (Check(sourceFile, destinationFolderPath, fileNames))
            {

                Console.WriteLine("=========MirrorRight test PASSED successfully=========");
            }
            else
            {


                Console.WriteLine("-------MirrorRight test FAILED-------");
            }
        }

    }
}
