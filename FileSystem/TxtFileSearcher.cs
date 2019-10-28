using System;
using Common;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public class TxtFileSearcher : IValidateParameters
    {
        public TxtFileSearcher(string sourceDirectory, string partialNameOfFile)
        {
            if(Validate(sourceDirectory) && Validate(partialNameOfFile))
            {
                this.SourceDirectory = sourceDirectory;
                this.PartialNameOfFile = partialNameOfFile;
            }
        }
        public string SourceDirectory { get; set; }
        public string PartialNameOfFile { get; set; }

        public void SearchTxtFiles( IWriter writer)
        { 
            try
            {
                var txtFiles = Directory.EnumerateFiles(SourceDirectory, "*.txt", SearchOption.AllDirectories);

                foreach (string currentFile in txtFiles)
                {
                    if (currentFile.Contains(PartialNameOfFile, StringComparison.CurrentCultureIgnoreCase)){
                        writer.Write(currentFile);
                    }
                    else
                    {
                        writer.Write("File does not found.");
                    }
                }
             }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine(dirEx.Message);
                throw new DirectoryNotFoundException("Directory not found: " + dirEx.Message);
            }

            catch (FileNotFoundException fileEx)
            {
                Console.WriteLine(fileEx.Message);
                throw new FileNotFoundException("File not found: " + fileEx.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Validate(string source)
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
