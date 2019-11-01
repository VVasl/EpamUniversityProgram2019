using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public partial class ConsoleService : IConsoleService
    {
        private StructsAndEnumsTasks structs;
        private ExceptionsTask exception;
        private FileSystemTasks files;
        private SerializationTasks serialization;
        private ReflectionTask info;
        private StyleCopShapesTasks shapes;
        private ExcelTasks excel;

        public ConsoleService()
        {
            structs = new StructsAndEnumsTasks();
            exception = new ExceptionsTask();
            files = new FileSystemTasks();
            serialization = new SerializationTasks();
            info = new ReflectionTask();
            shapes = new StyleCopShapesTasks();
            excel = new ExcelTasks();
            
        }
        public  void RunTasks()
        {
            bool endApp = false;
            Console.WriteLine("Viktoriia Vasyltsiv");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            while (!endApp)
            {
                Console.WriteLine("Choose task number from the following list:");
                Console.WriteLine("");
                Console.WriteLine("\t1   - Structs and Enums");
                Console.WriteLine("\t2   - Exceptions");
                Console.WriteLine("\t3   - File System");
                Console.WriteLine("\t4   - Serialization");
                Console.WriteLine("\t5   - Reflection");
                Console.WriteLine("\t6   - StypeCop");
                Console.WriteLine("\t7   - ExcelTask1");
                Console.WriteLine("Your Option?");
                string option = Console.ReadLine();
                Console.WriteLine("\n");

                switch (option)
                {
                    case "1":
                        structs.RunPersonTask();
                        structs.RunRectangleTask();
                        structs.RunMonthNameTask();
                        structs.RunOrderedColorsTask();
                        structs.RunMinMaxLongValueTask();
                        break;
                    case "2":
                        exception.StackOverflowExceptionTask();
                        exception.IndexOutOfRangeExceptionTask();
                        exception.ArgumentExceptionTask();
                        break;
                    case "3":
                        files.FileContentTask();
                        files.TxtFileSearcherTask();
                        break;
                    case "4":
                        serialization.RunBinary();
                        serialization.RunJson();
                        serialization.RunXml();
                        break;
                    case "5":
                        info.WriteInfoTask();
                        break;
                    case "6":
                        shapes.StyleCopRectangleTask();
                        shapes.StyleCopCircleTask();
                        break;
                    case "7":
                        excel.SearchUniqueValuesInExcelFileTask();
                        break;
                    default:
                        break;
                        //functions.Add(CalculatorTask);
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
                
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
        }
    }
}
