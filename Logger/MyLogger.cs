using System;
using System.IO;

namespace Logger
{
    public class MyLogger
    {
        public LogLevel MinLevel { get; set; } = LogLevel.Debug;

        public bool IsEnabled(LogLevel logLevel)
        { 
            return logLevel >= MinLevel;
        }
        public void Trace(string message, Operation op)
        {
            Log log;
            switch (op)
            {
                case Operation.LoggingToFile:
                    log = new FileLog(LogLevel.Trace, message);
                    log.Write();
                    break;
                
                case Operation.LoggingToConsole:
                    log = new ConsoleLog(LogLevel.Trace, message);
                    log.Write();
                    break;
            }
        }

        public void Debug(string message, Operation op)
        {
            Log log;
            switch (op)
            {
                case Operation.LoggingToFile:
                    log = new FileLog(LogLevel.Debug, message);
                    log.Write();
                    break;

                case Operation.LoggingToConsole:
                    log = new ConsoleLog(LogLevel.Debug, message);
                    log.Write();
                    break;
            }
        }

        public void Info(string message, Operation op)
        {
            Log log;
            switch (op)
            {
                case Operation.LoggingToFile:
                    log = new FileLog(LogLevel.Information, message);
                    log.Write();
                    break;

                case Operation.LoggingToConsole:
                    log = new ConsoleLog(LogLevel.Information, message);
                    log.Write();
                    break;
            }
        }

        public void Warn(string message, Operation op)
        {
            Log log;
            switch (op)
            {
                case Operation.LoggingToFile:
                    log = new FileLog(LogLevel.Warning, message);
                    log.Write();
                    break;

                case Operation.LoggingToConsole:
                    log = new ConsoleLog(LogLevel.Warning, message);
                    log.Write();
                    break;
            }
        }

        public void Error(string message, Operation op)
        {
            Log log;
            switch (op)
            {
                case Operation.LoggingToFile:
                    log = new FileLog(LogLevel.Error, message);
                    log.Write();
                    break;

                case Operation.LoggingToConsole:
                    log = new ConsoleLog(LogLevel.Error, message);
                    log.Write();
                    break;
            }
        }

        public void Critic(string message, Operation op)
        {
            Log log;
            switch (op)
            {
                case Operation.LoggingToFile:
                    log = new FileLog(LogLevel.Critical, message);
                    log.Write();
                    break;

                case Operation.LoggingToConsole:
                    log = new ConsoleLog(LogLevel.Critical, message);
                    log.Write();
                    break;
            }
        }

        public void ReadFromLogFile()
        {
            FileLog log = new FileLog();
            using (StreamReader r = new StreamReader(log.GetFileName()))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }   
        }
    }
}
