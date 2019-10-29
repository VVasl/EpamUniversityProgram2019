using System;
using FileSystem;
using Common;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace ConsoleApp
{
    public partial class ConsoleService : IConsoleService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private void FileContentTask()
        { 
            Console.Write("\n-----Task1-----FileSystem\n\n");
            logger.Info("FileSystem Task 1 : Content of the directory.\n");                      
            try
            {
                ContentOfTheDirectory content = new ContentOfTheDirectory(@"C:\Users\Victory\Documents\9");
                content.ShowAllDirectoryAndSubdirectoriesFiles(content.SourceDirectory, new MessageLogService());
               
            }

            catch (Exception e)
            {
                 logger.Error(e.Message);
            }
            finally
            {
                LogManager.Flush();
            }
        }


        private void TxtFileSearcherTask()
        {
            Console.Write("\n-----Task2-----TxtFiles\n\n");
            logger.Info("FileSystem Task 2 : Search for txt files in the directory.\n");
            try
            {
                TxtFileSearcher content = new TxtFileSearcher(@"C:\Users\Victory\Documents\9","Ide");
                content.SearchTxtFiles(new MessageLogService());

            }
            catch (Exception e)
            {
                logger.Error(e.Message, "String can't be null or empty.");
            }
            finally
            {
                LogManager.Flush();
            }


        }
    }
}
