using System;
using System.Reflection;
using Reflection;
using System.Linq;
using Common;
using System.Collections.Generic;


namespace ConsoleApp
{
    public partial class ConsoleService : IConsoleService
    {
        private const string AssemblyName = "StructsAndEnums.dll";
        private void WriteInfo()
        {
            Console.WriteLine("\t\tReflection Task : Write into console all assembly information");
            AllDllInformation info = new AllDllInformation(AssemblyName);
            info.GetAllInfo();
        }
    }   
}
