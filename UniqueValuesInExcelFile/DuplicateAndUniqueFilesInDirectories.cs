namespace UniqueValuesInExcelFile
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Common;

    public class DuplicateAndUniqueFilesInDirectories : IFilesSearch
    {
        private string firstDirectory;
        private string secondDirectory;
        private string searchPattern;

        public DuplicateAndUniqueFilesInDirectories(string firstDirectory, string secondDirectory, string searchPattern)
        {
            this.FirstDirectory = firstDirectory;
            this.SecondDirectory = secondDirectory;
            this.SearchPattern = searchPattern;
        }
        public string FirstDirectory
        {
            get
            {
                return this.firstDirectory;
            }

            set
            {
                ParameterValidation.AssertNotNullOrEmpty(value, nameof(value));
                this.firstDirectory = value;
            }
        }

        public string SecondDirectory
        {
            get
            {
                return this.secondDirectory;
            }

            set
            {
                ParameterValidation.AssertNotNullOrEmpty(value, nameof(value));
                this.secondDirectory = value;
            }
        }

        public string SearchPattern
        {
            get
            {
                return this.searchPattern;
            }

            set
            {
                ParameterValidation.AssertNotNullOrEmpty(value, nameof(value));
                this.searchPattern = value;
            }
        }

        public IEnumerable<string> GetDuplicateFilesFromDirectories()
        {
            var filesFromFirstDirectory = GetDuplicateFiles(this.FirstDirectory);
            var filesFromSecondDirectory = GetDuplicateFiles(this.SecondDirectory);

           return filesFromFirstDirectory.Union(filesFromSecondDirectory);
        }

        public HashSet<string> GetUniqueFilesFromDirectories()
        {

            var filesFromFirstDirectory = GetUniqueFiles(this.FirstDirectory);
            var filesFromSecondDirectory = GetUniqueFiles(this.SecondDirectory);

            filesFromFirstDirectory.SymmetricExceptWith(filesFromSecondDirectory);

            return filesFromFirstDirectory;
        }

        public IEnumerable<string> GetDuplicateFiles(string directoryName)
        {
            return Directory
                .GetFiles(directoryName, this.SearchPattern, SearchOption.AllDirectories)
                .GroupBy(file => Path.GetFileName(file))
                .Where(group => group.Count() > 1)
                .Select(group => group.Key);
        }

        public HashSet<string> GetUniqueFiles(string directoryName)
        {
            return Directory
               .GetFiles(directoryName, this.SearchPattern, SearchOption.AllDirectories)
               .Select(file => Path.GetFileName(file))
               .ToHashSet();
        }
    }
}
