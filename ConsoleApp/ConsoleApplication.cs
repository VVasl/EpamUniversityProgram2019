using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class ConsoleApplication
    {
        private readonly IConsoleService _consoleService;
        public ConsoleApplication(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }

        // Application starting point
        public void Run()
        {
            _consoleService.RunTasks();
        }
    }
}
