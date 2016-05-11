using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace folderSyncConsole
{
    public class ReaderWritter
    {

        public static void Readlines(string path, List<string> list)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
        }

        public static void Writelines(string outpath, List<string> list)
        {
            using (StreamWriter writer = new StreamWriter(outpath))
            {
                foreach (string line in list)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
}
