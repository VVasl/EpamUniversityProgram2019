namespace ConsoleApp
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using UniqueValuesInExcelFile;
    using OneDriveExcel;
    using Microsoft.Extensions.Configuration;

    class OneDriveExcelTask : Tasks
    {
        public void RunExcelTask()
        {
            var appConfig = LoadAppSettings();

            if (appConfig == null)
            {
                Console.WriteLine("Missing or invalid appsettings.json...exiting");
                return;
            }

            var appId = appConfig["appId"];
            var scopes = appConfig.GetSection("scopes").Get<string[]>();

            var authProvider = new DeviceCodeAuthProvider(appId, scopes);

            this.writer.Write("----------Task : Search for unique values in the excel file from the OneDrive.\n");
            var accessToken = authProvider.GetAccessToken().Result;

            GetUniqueValuesOneDrive();

        }

        public void GetUniqueValuesOneDrive()
        {
            string excelfile = this.configuration["excelFile"];
            
            try
            {
                UniqueValuesExcel excel = new UniqueValuesExcel(excelfile);

                var watch = System.Diagnostics.Stopwatch.StartNew();
                var countrylists = excel.GetLists(this.configuration["sheetForReading"], Int32.Parse(this.configuration["firstColumnToCompare"]), Int32.Parse(this.configuration["secondColumnToCompare"]), FileSource.OneDrive);
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
            catch(AggregateException ex)
            {
                logger.Error(ex.Message);
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
        
        public IConfigurationRoot LoadAppSettings()
        {
            if (string.IsNullOrEmpty(configuration["appId"]) ||
                string.IsNullOrEmpty(configuration["scopes:0"]))
            {
                return null;
            }

            return configuration;
        }
    }
    
}
