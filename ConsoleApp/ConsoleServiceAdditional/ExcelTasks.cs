namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using UniqueValuesInExcelFile;

    public class ExcelTasks : Tasks
    {
        public void SearchUniqueValuesInExcelFileTask()
        {
            this.writer.Write("----------Task 1: Search for unique values in the excel file.\n");
            string excelfile = this.configuration["excelFile"];

            try
            {
                UniqueValuesExcel excel = new UniqueValuesExcel(excelfile);

                var watch = System.Diagnostics.Stopwatch.StartNew();
                var countrylists = excel.GetLists(this.configuration["sheetForReading"], Int32.Parse(this.configuration["firstColumnToCompare"]), Int32.Parse(this.configuration["secondColumnToCompare"]), FileSource.FileSystem);
                watch.Stop();
                this.writer.Write($"ReadListsFromFile Method. Time Taken-->{watch.ElapsedMilliseconds}");

                watch.Start();
                HashSet<string> uniqueValuesList = excel.GetUniqueValuesFromLists(countrylists);
                watch.Stop();
                this.writer.Write($"GetUniqueValuesFromLists Method. Time Taken-->{watch.ElapsedMilliseconds}");

                watch.Start();
                Boolean outputBool;
                if (Boolean.TryParse(this.configuration["console"], out outputBool))
                {
                }

                if (outputBool)
                {
                    this.writer.Write($"\nThe list of unique values:");
                    foreach (var item in uniqueValuesList)
                    {
                        this.writer.Write($"\t{item}");
                    }
                }
                watch.Stop();
                this.writer.Write($"\nWriteToConsole. Time Taken-->{watch.ElapsedMilliseconds}");


                watch.Start();
                if (Boolean.TryParse(this.configuration["file"], out outputBool))
                {
                }

                if (outputBool)
                {
                    ExcelFileInputOutput.WriteToExcel(excelfile, uniqueValuesList, configuration["sheetForWritingUniqueValues"]);
                }
                watch.Stop();
                this.writer.Write($"WriteToExcel Method. Time Taken-->{watch.ElapsedMilliseconds}");
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.Message);
            }

            catch (IOException ex)
            {
                logger.Error(ex.Message);
            }

        }

        public void SearchDuplicateAndUniqueFilesInDirectoriesTask()
        {
            this.writer.Write("\n\n----------Task 2: Search for unique and duplicate files in the directories .\n");
            try
            {
                DuplicateAndUniqueFilesInDirectories excelDirectories = new DuplicateAndUniqueFilesInDirectories(this.configuration["firstDirectoryExcel"], this.configuration["secondDirectoryExcel"], "*.xlsx");
                string excelfile = this.configuration["excelFile"];
                var watch = System.Diagnostics.Stopwatch.StartNew();
                IEnumerable<string> duplicateFiles = excelDirectories.GetDuplicateFilesFromDirectories();
                watch.Stop();
                this.writer.Write($"GetDuplicateFilesFromDirectories Method. Time Taken-->{watch.ElapsedMilliseconds}");

                watch.Start();
                HashSet<string> uniqueFiles = excelDirectories.GetUniqueFilesFromDirectories();
                watch.Stop();
                this.writer.Write($"GetUniqueFilesFromDirectories Method. Time Taken-->{watch.ElapsedMilliseconds}");

                watch.Start();
                Boolean outputBool;
                if (Boolean.TryParse(this.configuration["console"], out outputBool))
                {
                }

                if (outputBool)
                {
                    this.writer.Write($"\nThe list of duplicate files:");
                    foreach (var item in duplicateFiles)
                    {
                        this.writer.Write($"\t{item}");
                    }

                    this.writer.Write($"\nThe list of unique files:");
                    foreach (var item in uniqueFiles)
                    {
                        this.writer.Write($"\t{item}");
                    }
                }
                watch.Stop();
                this.writer.Write($"\nWriteToConsole. Time Taken-->{watch.ElapsedMilliseconds}");


                watch.Start();
                if (Boolean.TryParse(this.configuration["file"], out outputBool))
                {
                }

                if (outputBool)
                {
                    ExcelFileInputOutput.WriteToExcel(excelfile, duplicateFiles, configuration["sheetForWritingDuplicateFiles"]);
                    ExcelFileInputOutput.WriteToExcel(excelfile, uniqueFiles, configuration["sheetForWritingUniqueFiles"]);
                }
                watch.Stop();
                this.writer.Write($"WriteToExcel Method. Time Taken-->{watch.ElapsedMilliseconds}");
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.Message);
            }

            catch (IOException ex)
            {
                logger.Error(ex.Message);
            }
        }
    }
}
