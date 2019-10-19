using System;
using System.Text;


namespace Logger
{
     abstract class Log 
    {
        public LogLevel Level { get; set; }

        public string Message { get; set; }

        public DateTime CreationDateTime { get; set; }
        

        public Log(LogLevel level, string message)
        {
            Level = level;
            Message = message;
            CreationDateTime = DateTime.Now;
        }

        //  bool IsEnabled(LogLevel logLevel);
        // void Read(StreamReader r);

        public string BuildLog()
        {
            var logBuilder = new StringBuilder();
            try
            {
                if (!string.IsNullOrEmpty(Message))
                {
                    logBuilder.Append(CreationDateTime);
                    logBuilder.Append('\t');
                    logBuilder.Append((int)Level);
                    logBuilder.Append("\t[");
                    logBuilder.Append(Level);
                    logBuilder.Append("]\t");
                    logBuilder.Append(Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return logBuilder.ToString();
        }

        abstract public void Write();

    }  
}
