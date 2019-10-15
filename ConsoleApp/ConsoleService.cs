using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public partial class ConsoleService : IConsoleService
    {
        public  void RunTasks()
        {
            List<Action> functions = new List<Action>();
            //functions.Add(RunPersonTask);
            //functions.Add(RunRectangleTask);
            //functions.Add(RunMonthNameTask);
            //functions.Add(RunOrderedColorsTask);
            //functions.Add(RunMinMaxLongValueTask);

            //functions.Add(StackOverflowExceptionTask);
            //functions.Add(IndexOutOfRangeExceptionTask);
            //functions.Add(ArgumentExceptionTask);

            functions.Add(FileContentTask);
            functions.Add(TxtFileSearcherTask);


            foreach (Action func in functions)
                func();
        }
    }

}
