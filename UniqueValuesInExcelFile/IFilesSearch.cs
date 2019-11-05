namespace UniqueValuesInExcelFile
{
    using System.Collections.Generic;

    public interface IFilesSearch
    {
        HashSet<string> GetUniqueFiles(string directoryName);

        IEnumerable<string> GetDuplicateFiles(string directoryName);
    }
}
