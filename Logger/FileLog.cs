﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Logger
{
    class FileLog : Log
    {
        private string MessageExePath { get; set; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public FileLog() : base(){}
        public FileLog(LogLevel level, string message) : base(level, message){}
        public  string GetFileName()
        {
            string fileForLogging = String.Empty;
            var builder = new ConfigurationBuilder()
                .SetBasePath(MessageExePath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            fileForLogging = configuration["fileForLogging"];
            return fileForLogging;
        }
        
        public override void Write()
        {
            string file = GetFileName();
            Console.WriteLine(file);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(MessageExePath, file), true))
            {
                outputFile.WriteLine(BuildLog());
            }
        }
    }
}
