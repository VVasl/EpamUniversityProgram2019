using System;
using Common;
using System.IO;

namespace FileSystem
{
    public class TxtFileSearcher 
    {
        public TxtFileSearcher(string sourceDirectory, string partialNameOfFile)
        {
            ParameterValidation.AssertNotNullOrEmpty(partialNameOfFile, nameof(partialNameOfFile));
            this.SourceDirectory = sourceDirectory;
            this.PartialNameOfFile = partialNameOfFile;
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
                        writer.Write($"\tFile: {currentFile}");
                    }
                    else
                    {
                        throw new FileNotFoundException("File not found");
                    }
                }
             }

            catch (DirectoryNotFoundException)
            {
                throw;
            }
        }
    }
}
