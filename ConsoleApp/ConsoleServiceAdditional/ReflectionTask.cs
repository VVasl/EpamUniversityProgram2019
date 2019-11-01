using Reflection;
using Common;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleApp
{
    public class ReflectionTask
    {
        private IWriter writer;
        private readonly IConfigurationRoot configuration;

        public ReflectionTask()
        {
            this.writer = new ConsoleInputOutput();

            this.configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", true, true).Build();
        }
        public void WriteInfoTask()
        {
            this.writer.Write("\tReflection Task : Write into console all assembly information");
            AllDllInformation info = new AllDllInformation(this.configuration["assemblyName"]);
            info.GetAllInfo(this.writer);
        }
    }   
}
