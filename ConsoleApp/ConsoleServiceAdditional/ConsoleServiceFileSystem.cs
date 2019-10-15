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
        private void FileContentTask()
        { 
            Console.Write("\n-----Task1-----FileSystem\n\n");
                                  
            try
            {
                ContentOfTheDirectory content = new ContentOfTheDirectory { SourceDirectory = @"C:\Users\Victory\Documents\9" };
                if(content.Validate())
                    content.ShowAllDirectoryAndSubdirectoriesFiles(content.SourceDirectory, new MessageLogService());
               
            }

            catch (Exception )
            {
                 Logger logger = LogManager.GetCurrentClassLogger();
                 logger.Error("e.Message");
            }
        }


        private void TxtFileSearcherTask()
        {

            Console.Write("\n-----Task2-----TxtFiles\n\n");


            try
            {
                TxtFileSearcher content = new TxtFileSearcher { SourceDirectory = @"C:\Users\Victory\Documents\9", PartialNameOfFile = "Ide" };
                content.SearchTxtFiles(new MessageLogService());

            }
            catch (Exception e)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(e.Message);
            }


        }
    }
}
