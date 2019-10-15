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
        static int counter = 0;
        public string SourceDirectory { get; set; }

        public void ShowAllDirectoryAndSubdirectoriesFiles(string sourceDirectory, IWriter writer)
        {
                string[] files = Directory.GetFiles(sourceDirectory);
                foreach (string file in files)
                {
                    writer.Write($"\tFile: {file}");
                }


                string[] subDirectories = Directory.GetDirectories(sourceDirectory);

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

        public bool Validate()
        {
            var isValid = true;
            
                if (string.IsNullOrWhiteSpace(SourceDirectory) || SourceDirectory.Trim().Length == 0)
                {
                    isValid = false;
                    throw new ArgumentException("String can't be null or empty.");
                }
            

            return isValid;
        }

    }
}
