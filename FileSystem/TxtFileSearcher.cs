using System;
using Common;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FileSystem
{
    public class TxtFileSearcher : IValidateParameters
    {
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
                }
             }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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

            if (string.IsNullOrWhiteSpace(PartialNameOfFile) || PartialNameOfFile.Trim().Length == 0)
            {
                isValid = false;
                throw new ArgumentException("String can't be null or empty.");
            }


            return isValid;
        }
    }
}
