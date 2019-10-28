using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IWriter
    {
        void Write(string msg);
        void Show(Int32 indent, String format, params Object[] args);
    }
}
