using System;
using Common;

namespace Logger
{
    class ConsoleLog : Log
    {
        public ConsoleLog(LogLevel level, string message) : base(level, message)
        { }

        public override void Write()
        {
            MessageLogService writer = new MessageLogService();
            writer.Write(BuildLog());
        }

    }
}
