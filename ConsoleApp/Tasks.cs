
namespace ConsoleApp
{
    using Common;
    using System.IO;
    using NLog;
    using Microsoft.Extensions.Configuration;

    public abstract class Tasks
    {
        public IWriter writer;
        public Logger logger;
        public readonly IConfigurationRoot configuration;

        protected Tasks()
        {
            this.writer = new ConsoleInputOutput();

            this.logger = LogManager.GetCurrentClassLogger();

            this.configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", true, true).Build();
        }
    }
}
