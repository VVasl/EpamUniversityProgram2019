using System;
using System.IO;
using Common; 

namespace FileSystem
{
    public class ContentOfTheDirectory 
    {
        private const int MaxRecursiveCalls = 1000;

        public ContentOfTheDirectory(string sourceDirectory)
        {
            ParameterValidation.AssertNotNullOrEmpty(sourceDirectory, nameof(sourceDirectory));
            this.SourceDirectory = sourceDirectory;
        }
        public string SourceDirectory { get; set; }

        public void ShowAllDirectoryAndSubdirectoriesFiles(string sourceDirectory, IWriter writer)
        {
            try
            {
                string[] files = Directory.GetFiles(sourceDirectory);
                foreach (string file in files)
                {
                    writer.Write($"\tFile: {file}");
                }
                
                string[] subDirectories = Directory.GetDirectories(sourceDirectory);
                int counter = 0;
                foreach (string subDirectory in subDirectories)
                {
                    writer.Write($"Subdirectory: {subDirectory}");

                    counter++;
                    if (counter <= MaxRecursiveCalls)
                        ShowAllDirectoryAndSubdirectoriesFiles(subDirectory, writer);
                    else
                        throw new StackOverflowException("Detected unhandled exception: Stack overflow.");
                }
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
        }
    }
}
