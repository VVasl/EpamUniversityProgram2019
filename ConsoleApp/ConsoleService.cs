namespace ConsoleApp
{
    using System;

    public partial class ConsoleService : IConsoleService
    {
        private readonly StructsAndEnumsTasks structs;
        private readonly ExceptionsTask exception;
        private readonly FileSystemTasks files;
        private readonly SerializationTasks serialization;
        private readonly ReflectionTask info;
        private readonly StyleCopShapesTasks shapes;
        private readonly ExcelTasks excel;
        private readonly CalculatorTasks calculator;
        private readonly AsynchronousTasks thread;
        private readonly OneDriveExcelTask excelOneDrive;

        public ConsoleService()
        {
            this.structs = new StructsAndEnumsTasks();
            this.exception = new ExceptionsTask();
            this.files = new FileSystemTasks();
            this.serialization = new SerializationTasks();
            this.info = new ReflectionTask();
            this.shapes = new StyleCopShapesTasks();
            this.excel = new ExcelTasks();
            this.calculator = new CalculatorTasks();
            this.thread = new AsynchronousTasks();
            this.excelOneDrive = new OneDriveExcelTask();


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
                Console.WriteLine("\t7   - ExcelTasks");
                Console.WriteLine("\t8   - Calculator");
                Console.WriteLine("\t9   - AsynchronousProgramming");
                Console.WriteLine("\t10   - OneDriveExcel");
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
                        excel.SearchDuplicateAndUniqueFilesInDirectoriesTask();
                        break;
                    case "8":
                        calculator.CalculatorTaskConsole();
                        calculator.CalculatorTaskFile();
                        break;
                    case "9":
                        thread.RunSequentialSumOfArrayTask();
                        thread.RunParallelForTask();
                        break;
                    case "10":
                        excelOneDrive.RunExcelTask();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("-----------------------------------------------------------------------------------");
                
                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
        }
    }
}
