using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class MessageLogService : IReader, IWriter 
    {
        public void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
