using System;
using System.IO;
using Common;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
    public class ContentOfTheDirectory : IValidateParameters
    {
        private const int MAX_RECURSIVE_CALLS = 1000;

        public ContentOfTheDirectory(string sourceDirectory)
        {
            if (Validate(sourceDirectory))
            {
                this.SourceDirectory = sourceDirectory;
            }
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
                    if (counter <= MAX_RECURSIVE_CALLS)
                        ShowAllDirectoryAndSubdirectoriesFiles(subDirectory, writer);
                    else
                        throw new StackOverflowException("Detected unhandled exception: Stack overflow.");
                }
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine(dirEx.Message);
                throw new DirectoryNotFoundException("Directory not found: " + dirEx.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Validate( string source)
        {
            var isValid = true;
            
                if (string.IsNullOrWhiteSpace(source) || source.Trim().Length == 0)
                {
                    throw new ArgumentException("String can't be null or empty.");
                }
            

            return isValid;
        }
    }
}
