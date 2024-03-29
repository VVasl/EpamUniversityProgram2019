﻿namespace ConsoleApp
{
    using System;
    using FileSystem;
    using System.IO;
    using NLog;

    public  class FileSystemTasks : Tasks
    {
        public void FileContentTask()
        { 
            this.writer.Write("\n-----Task1-----FileSystem\n\n");
            logger.Info("FileSystem Task 1 : Content of the directory.\n");                      
            try
            {
                ContentOfTheDirectory content = new ContentOfTheDirectory(this.configuration["directory"]);
                content.ShowAllDirectoryAndSubdirectoriesFiles(content.SourceDirectory, this.writer);
               
            }

            catch (DirectoryNotFoundException dirEx)
            {
                this.writer.Write(dirEx.Message);
                logger.Error("Directory not found: " + dirEx.Message);
            }

            catch (FileNotFoundException fileEx)
            {
                this.writer.Write(fileEx.Message);
                logger.Info("File not found: " + fileEx.Message);
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


        public void TxtFileSearcherTask()
        {
            this.writer.Write("\n-----Task2-----TxtFiles\n\n");
            logger.Info("FileSystem Task 2 : Search for txt files in the directory.\n");
            try
            {
                TxtFileSearcher content = new TxtFileSearcher(this.configuration["directory"], "Ide");
                content.SearchTxtFiles(writer);

            }
            catch (DirectoryNotFoundException dirEx)
            {
                this.writer.Write(dirEx.Message);
                logger.Error("Directory not found: " + dirEx.Message);
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
