namespace UniqueValuesInExcelFile
{
    using System.Collections.Generic;
    using System.IO;
    using OfficeOpenXml;
    public static class ExcelFileInputOutput
    {
        public static IEnumerable<string> ReadListFromFile(string excelFile, string sheetForReading, int columnToCompare)
        {
            List<string> list = new List<string>() { };

            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFile)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetForReading];

                int rowCount = worksheet.Dimension.End.Row;

                for (int row = 1; row <= rowCount; row++)
                {
                    list.Add(worksheet.Cells[row, columnToCompare].Value.ToString());
                }
            }
            return list;
        }

        public static void WriteToExcel(string excelFile, IEnumerable<string> list, string sheetForWriting)
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
