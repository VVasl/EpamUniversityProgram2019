using System;
using Exceptions;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public partial class ConsoleService : IConsoleService
    {
        private void StackOverflowExceptionTask()
        {
            Console.Write("\n-----Task1-----StackOverflowException\n\n");
            try
            {
                ExceptionSituations.Recurse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            
        }

        private void IndexOutOfRangeExceptionTask()
        {
            int n = 7;

            Console.Write("\n-----Task2-----IndexOutOfRangeException\n\n");

            try
            {
                ExceptionSituations.WriteArray(n, 100);
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ArgumentExceptionTask()
        {
            Console.Write("\n-----Task3-----ArgumentException\n\n");

            int a, b;

            Console.Write("Enter a: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter b: ");
            b = Convert.ToInt32(Console.ReadLine());

            try
            {
                int multiplicationResult = ExceptionSituations.DoSomeMath(a, b);
                Console.WriteLine($"The result of multiplication: {multiplicationResult}");
            }
            catch (System.ArgumentException e)
            when (a < 0)
            {
                Console.WriteLine(e.Message);
            }

            catch (System.ArgumentException e)
            when (b > 0)
            {
                Console.WriteLine(e.Message);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
