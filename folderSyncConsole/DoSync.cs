
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;


namespace folderSyncConsole
{
    public class DoSync
    {

        private string sourceFolderPath;
        private string destinationFolderPath;
        private int direction;
        private FileSyncScopeFilter filter;
        private FileSyncOptions options;
        private FileSyncProvider sourceFolderProvider = null;
        private FileSyncProvider destinationFolderProvider = null;

        public DoSync(string sourceFolder, string destinationFolder, FileSyncScopeFilter outFilter, FileSyncOptions outOptions, int outDirection)
        {
            sourceFolderPath = sourceFolder;
            destinationFolderPath = destinationFolder;
            filter = outFilter;
            options = outOptions;
            direction = outDirection;
        }

        public void Sync()
        {

            sourceFolderProvider = new FileSyncProvider(sourceFolderPath, filter, options);
            destinationFolderProvider = new FileSyncProvider(destinationFolderPath, filter, options);
            SyncOrchestrator sync = new SyncOrchestrator();
            sync.LocalProvider = sourceFolderProvider;
            sync.RemoteProvider = destinationFolderProvider;
            
            switch (direction)  //TO DO: Change numbers to enums.
            {
                case Program.updateRight:
                    sync.Direction = SyncDirectionOrder.Upload;
                    break;
                case Program.updateLeft:
                    sync.Direction = SyncDirectionOrder.Download;
                    break;
                case Program.updateBoth:
                    sync.Direction = SyncDirectionOrder.DownloadAndUpload;
                    break;

                case Program.mirrorToLeft:
                    sync.Direction = SyncDirectionOrder.Download;
                    DeleteDifference(destinationFolderPath, sourceFolderPath);
                    break;

                case Program.mirrorToRight:
                    sync.Direction = SyncDirectionOrder.Upload;
                    DeleteDifference(sourceFolderPath, destinationFolderPath);
                    break;
            }

            string msg;
            try
            {
                // Synchronize data between the two providers.
                SyncOperationStatistics stats = sync.Synchronize();

                // Display statistics for the synchronization operation.
                msg = "Synchronization succeeded!\n\n" +
                    stats.DownloadChangesApplied + " download changes applied\n" +
                    stats.DownloadChangesFailed + " download changes failed\n" +
                    stats.UploadChangesApplied + " upload changes applied\n" +
                    stats.UploadChangesFailed + " upload changes failed";
            }
            catch (Exception ex)
            {
                msg = "Synchronization failed! Here's why: \n\n" + ex.Message;
            }
            Console.WriteLine(msg, "Synchronization Results");
        }

        private void DeleteDifference(string sourcePath, string destPath)
        {

            System.IO.DirectoryInfo destDir = new DirectoryInfo(destPath);
            System.IO.DirectoryInfo sourceDir = new DirectoryInfo(sourcePath);
            int i = 0;
            int count = sourceDir.GetFiles().Length;
            string[] sourceFilesArray = new string[count];
            foreach (FileInfo file in sourceDir.GetFiles()) //Added filesync.metadata file
            {
                string currentFileName = file.FullName;
                sourceFilesArray[i] = Path.GetFileName(currentFileName);
                i++;
            }

            foreach (FileInfo file in destDir.GetFiles())
            {
                bool needDelete = false;
                string fileName = Path.GetFileName(file.FullName);
                for (int j = 0; j < count; j++)
                {
                    
                    if (fileName == sourceFilesArray[j])
                    {
                        needDelete = false;
                        break;
                    }
                    else
                    {
                        needDelete = true; 
                    }
                }
                if (needDelete)
                {
                    file.Delete();
                }
            }
          Console.ReadLine();
        }


    }




}

