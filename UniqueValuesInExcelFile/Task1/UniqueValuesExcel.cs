namespace UniqueValuesInExcelFile
{   
    using System;
    using System.Collections.Generic;
    using Common;

    public class UniqueValuesExcel : IValuesSearch
    {
        private string excelFile;
        public UniqueValuesExcel(string excelFile)
        {
            this.ExcelFile = excelFile;
        }

        public string ExcelFile
        {
            get
            {
                return this.excelFile;
            }

            set
            {
                ParameterValidation.AssertNotNullOrEmpty(value, nameof(value));
                this.excelFile = value;
            }
        }

        public Tuple<HashSet<string>, HashSet<string>> GetLists(string sheetForReading, int firstColumnToCompare, int secondColumnToCompare, FileSource source)
        {
            var countryListFirst = new HashSet<string>(ExcelFileInputOutput.ReadListFromFile(this.ExcelFile, sheetForReading, firstColumnToCompare, source));
            var countryListSecond = new HashSet<string>(ExcelFileInputOutput.ReadListFromFile(this.ExcelFile, sheetForReading, secondColumnToCompare,source));

                countryListFirst.UnionWith(countryListSecond); 

            return Tuple.Create(countryListFirst, countryListSecond);
        }

        public HashSet<string> GetUniqueValuesFromLists(Tuple<HashSet<string>, HashSet<string>> countrylists)
        {
            HashSet<string> countryListFirst = countrylists.Item1;
            HashSet<string> countryListSecond = countrylists.Item2;

            countryListFirst.UnionWith(countryListSecond);

            return countryListFirst;
        }
    }
}
