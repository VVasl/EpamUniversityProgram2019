namespace ConsoleApp
{
    using System;
    using Exceptions;

    public class ExceptionsTask : Tasks
    {
        public void StackOverflowExceptionTask()
        {
            this.writer.Write("\n-----Task1-----StackOverflowException\n\n");
            try
            {
                ExceptionSituations.Recurse();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void IndexOutOfRangeExceptionTask()
        {
            int n = 7;

            this.writer.Write("\n-----Task2-----IndexOutOfRangeException\n\n");

            try
            {
                ExceptionSituations.InstantiateArray(n, 100);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ArgumentExceptionTask()
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
            catch (ArgumentException e)
            when (e.ParamName == "a")
            {
                Console.WriteLine(e.Message);
            }

            catch (ArgumentException e)
            when (e.ParamName == "b")
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
