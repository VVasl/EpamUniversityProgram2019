using System;
using System.Text;


namespace Logger
{
    abstract class Log 
    {
        protected Log(){}

        protected Log(LogLevel level, string message)
        {
            this.Level = level;
            this.Message = message;
            this.CreationDateTime = DateTime.Now;
        }

        public LogLevel Level { get; set; }

        public string Message { get; set; }

        public DateTime CreationDateTime { get; set; }
        
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
