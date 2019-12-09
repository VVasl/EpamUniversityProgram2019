using System;
using Common;

namespace Logger
{
    class ConsoleLog : Log
    {
        private readonly IWriter writer;

        public ConsoleLog(LogLevel level, string message) : base(level, message)
        {
            this.writer = new ConsoleInputOutput();
        }

        public override void Write()
        {
            this.writer.Write(BuildLog());
        }

    }
}
