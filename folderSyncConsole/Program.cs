using Microsoft.Synchronization.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft;

namespace folderSyncConsole
{
    class Program
    {
        public const int updateLeft = 1;
        public const int updateRight = 2;
        public const int updateBoth = 3;
        public const int mirrorToLeft = 4;
        public const int mirrorToRight = 5;

        static void Main(string[] args)
        {

            string sourceFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\SourceFolder\";

            string destinationFolderPath = Directory.GetCurrentDirectory() + @"\MyDir\DestinationFolder\";
            int direction = 0;
            

            FileSyncScopeFilter mainFilter = new FileSyncScopeFilter();
            FileSyncOptions mainOptions = new FileSyncOptions();

            UnitTest test = new UnitTest();

            //UpdateLeft
            test.Prepare();
            direction = updateLeft;
            DoSync doSync2 = new DoSync(sourceFolderPath, destinationFolderPath, mainFilter, mainOptions, direction);
            doSync2.Sync();
            UnitTest.UpdateLeft();

            //UpdateRight
            test.Prepare();
            direction = updateRight;
            DoSync doSync1 = new DoSync(sourceFolderPath, destinationFolderPath, mainFilter, mainOptions, direction);
            doSync1.Sync();
            UnitTest.UpdateRight();

            //UpdateBoth
            test.Prepare();
            direction = updateBoth;
            DoSync doSync3 = new DoSync(sourceFolderPath, destinationFolderPath, mainFilter, mainOptions, direction);
            doSync3.Sync();
            UnitTest.UpdateBoth();

            //MirrorToLeft
            direction = mirrorToLeft;
            test.Prepare();
            DoSync doSync4 = new DoSync(sourceFolderPath, destinationFolderPath, mainFilter, mainOptions, direction);
            doSync4.Sync();
            UnitTest.MirrorToLeft();

            //MirrorToRight
            direction = mirrorToRight;
            test.Prepare();
            DoSync doSync5 = new DoSync(sourceFolderPath, destinationFolderPath, mainFilter, mainOptions, direction);
            doSync5.Sync();
            UnitTest.MirrorToRight();



            //UnitTest.UpdateLeft();
            
            Console.ReadLine();

        }


    }
}
