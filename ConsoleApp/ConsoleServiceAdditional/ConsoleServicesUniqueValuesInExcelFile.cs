using System;
using UniqueValuesInExcelFile;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Common;
using System.Collections.Generic;


namespace ConsoleApp
{
    public partial class ConsoleService : IConsoleService
    {
        private readonly IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();

        private void SearchUniqueValuesInExcelFileTask()
        {
            Console.WriteLine("Task: Search for unique values in the excel file.\n");
            string excelfile = configuration["excelFile"];
            UniqueValuesExcel excel = new UniqueValuesExcel();

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var countrylists = excel.ReadListsFromFile(excelfile, configuration["sheetForReading"], Int32.Parse(configuration["firstColumnToCompare"]), Int32.Parse(configuration["secondColumnToCompare"]));
            watch.Stop();
            Console.WriteLine($"ReadListsFromFile Method. Time Taken-->{watch.ElapsedMilliseconds}");

            watch.Start();
            HashSet<string> uniqueValuesList = excel.GetUniqueValuesFromLists(countrylists);
            watch.Stop();
            Console.WriteLine($"GetUniqueValuesFromLists Method. Time Taken-->{watch.ElapsedMilliseconds}");

            watch.Start();
            Boolean outputBool;
            if (Boolean.TryParse(configuration["console"], out outputBool))
            {
            }

            if (outputBool)
            {
                foreach (var item in uniqueValuesList)
                {
                    Console.WriteLine($"\t{item}");
                }
            }
            watch.Stop();
            Console.WriteLine($"\nWriteToConsole. Time Taken-->{watch.ElapsedMilliseconds}");

            watch.Start();

            if (Boolean.TryParse(configuration["file"], out outputBool))
            {
            }

            if (outputBool)
            {
                excel.WriteToExcel(excelfile, uniqueValuesList, configuration["sheetForWriting"]);
            }
            watch.Stop();
            Console.WriteLine($"WriteToExcel Method. Time Taken-->{watch.ElapsedMilliseconds}");

        }
        

    }
}
