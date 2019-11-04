﻿namespace ConsoleApp
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using UniqueValuesInExcelFile;
    using Microsoft.Extensions.Configuration;
    using NLog;
    using Common;

    public class ExcelTasks
    {
        private IWriter writer;
        private static Logger logger;
        private readonly IConfigurationRoot configuration;

        public ExcelTasks()
        {
            this.writer = new ConsoleInputOutput();

            logger = LogManager.GetCurrentClassLogger();

            this.configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", true, true).Build();
        }

        public void SearchUniqueValuesInExcelFileTask()
        {
            this.writer.Write("Task: Search for unique values in the excel file.\n");
            string excelfile = this.configuration["excelFile"];
            UniqueValuesExcel excel = new UniqueValuesExcel();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var countrylists = excel.ReadListsFromFile(excelfile, this.configuration["sheetForReading"], Int32.Parse(this.configuration["firstColumnToCompare"]), Int32.Parse(this.configuration["secondColumnToCompare"]));
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
                excel.WriteToExcel(excelfile, uniqueValuesList, configuration["sheetForWriting"]);
            }
            watch.Stop();
            this.writer.Write($"WriteToExcel Method. Time Taken-->{watch.ElapsedMilliseconds}");
        }
    }
}