using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft
{
    public class CompareFolders
    {
        private string sourceFolderPath;
        private string destinationFolderPath;
        private List<string> differenceList;

        public CompareFolders(string sourceFolder, string destinationFolder)
        {
            sourceFolderPath = sourceFolder;
            destinationFolderPath = destinationFolder;
        }

        
        public List<string> Compare()
        {
            
            differenceList = new List<string>();

            // Take a snapshot of the file system.
            IEnumerable<System.IO.FileInfo> list1 = CreateListOfFiles(sourceFolderPath);
            IEnumerable<System.IO.FileInfo> list2 = CreateListOfFiles(destinationFolderPath);


            //A custom file comparer defined below
            FileCompare myFileCompare = new FileCompare();

            // This query determines whether the two folders contain identical file lists
            bool areIdentical = list1.SequenceEqual(list2, myFileCompare);

            if (areIdentical == true)
            {
                Console.WriteLine("the two folders are the same");
            }
            else
            {
                Console.WriteLine("The two folders are not the same");
            }

            // Find the set difference between the two folders.
            var queryList1Only = (from file in list1
                                  select file).Except(list2, myFileCompare);

            Console.WriteLine("The following files are in list1 but not list2:");
            foreach (var v in queryList1Only)
            {
                differenceList.Add(v.Name);
            }
            return differenceList;
        }

        public IEnumerable<System.IO.FileInfo> CreateListOfFiles(string dirPath)
        {

            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(dirPath);
            

            // Take a snapshot of the file system.
            IEnumerable<System.IO.FileInfo> listForReturn = dir.GetFiles("*.*", System.IO.SearchOption.AllDirectories);

            return listForReturn;
        }
    }


    // Compare files
    class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
    {
        public FileCompare() { }

        public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
        {
            return (f1.Name == f2.Name &&
                    f1.Length == f2.Length);
        }


        // Return file hash code.
        public int GetHashCode(System.IO.FileInfo fi)
        {
            string s = String.Format("{0}{1}", fi.Name, fi.Length);
            return s.GetHashCode();
        }
    }
}
