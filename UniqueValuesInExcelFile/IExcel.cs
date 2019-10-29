namespace UniqueValuesInExcelFile
{
    using System;
    using System.Collections.Generic;

    public interface IExcel
    {
        Tuple<HashSet<string>, HashSet<string>> ReadListsFromFile(string excelFile, string sheetForReading, int firstColumnToCompare, int secondColumnToCompare);
        
        void WriteToExcel(string excelFile, HashSet<string> list, string sheetForWriting);
    }
}
