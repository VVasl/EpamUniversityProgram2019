namespace UniqueValuesInExcelFile
{   
    using System;
    using System.Collections.Generic;
    using System.IO;
    using OfficeOpenXml;

    public class UniqueValuesExcel : IExcel
    {
        public  Tuple<HashSet<string>, HashSet<string>> ReadListsFromFile(string excelFile, string sheetForReading, int firstColumnToCompare, int secondColumnToCompare)
        {
            var countryListFirst = new HashSet<string>();
            var countryListSecond = new HashSet<string>();

            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFile)))
            {
                // Get the first worksheet in the workbook.
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetForReading];

                // Get row count.
                int rowCount = worksheet.Dimension.End.Row;     
                              
                for (int row = 1; row <= rowCount; row++)
                {
                    countryListFirst.Add(worksheet.Cells[row, firstColumnToCompare].Value.ToString());
                    countryListSecond.Add(worksheet.Cells[row, secondColumnToCompare].Value.ToString());
                }

                countryListFirst.UnionWith(countryListSecond);   
            }

            return Tuple.Create(countryListFirst, countryListSecond);
        }

        public HashSet<string> GetUniqueValuesFromLists(Tuple<HashSet<string>, HashSet<string>> countrylists)
        {
            HashSet<string> countryListFirst = countrylists.Item1;
            HashSet<string> countryListSecond = countrylists.Item2;

            countryListFirst.UnionWith(countryListSecond);

            return countryListFirst;
        }

        public void WriteToExcel(string excelFile, HashSet<string> list, string sheetForWriting)
        {
            using (var package = new ExcelPackage(new FileInfo(excelFile)))
            { 
                var worksheet = package.Workbook.Worksheets[sheetForWriting];

                int row = 1;
                foreach (var item in list)
                {
                    worksheet.Cells[row, 1].Value = item;
                    row++;
                }

                package.Save();
            }
        }
    }
}
