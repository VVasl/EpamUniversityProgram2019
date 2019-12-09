namespace UniqueValuesInExcelFile
{
    using System;
    using System.IO;
    using OfficeOpenXml;
    using OneDriveExcel;
    static class ExcelPackageSource
    {
        public static ExcelPackage GetExcelPackageSource(string excelFile, FileSource source)
        {
            ExcelPackage package;

            switch (source)
            {
                case FileSource.FileSystem:
                    {
                        package = new ExcelPackage(new FileInfo(excelFile));
                        break;
                    }
                case FileSource.OneDrive:
                    {
                        package = new ExcelPackage(GraphHelper.GetFileAsync(excelFile).Result);
                        break;
                    }
                default:
                    throw new ArgumentOutOfRangeException($"Source {source} is not implemented!");
            }

            return package;
        }
    }
}
