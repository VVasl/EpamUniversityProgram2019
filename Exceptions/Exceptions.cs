using System;

namespace Exceptions
{
    public class ExceptionSituations
    {
        private const int MAX_RECURSIVE_CALLS = 1000;
        static int counter = 0;

        public static void Recurse()
        {
            counter++;
            if (counter <= MAX_RECURSIVE_CALLS)
                Recurse();
            else
                throw new StackOverflowException("Detected unhandled exception: Stack overflow.");
        }

        public static void InstantiateArray(int n, int maxValue)
        {
            int[] array = new int[n];
            Random rnd = new Random();
            for (int i = 0; i <= array.Length; i++)
            {
                array[i] = rnd.Next(0, maxValue + 1);
            }
        }

        public static int DoSomeMath(int a, int b)
        {
            if (a < 0)
            {
                throw new ArgumentException("Parameter should be greater than 0", "a");
            }

            if (b > 0)
            {
                throw new ArgumentException("Parameter should be less than 0", "b");
            }

            return a * b;
        }
    }
}
