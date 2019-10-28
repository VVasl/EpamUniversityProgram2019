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
        public void Show(Int32 indent, String format, params Object[] args)
        {
            Console.WriteLine(new String(' ', 3 * indent) + format, args);

        }

        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
