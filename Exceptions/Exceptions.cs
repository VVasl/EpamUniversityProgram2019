using System;

namespace Exceptions
{
    public static class ExceptionSituations
    {
        private const int MaxRecursiveCalls = 1000;
        static int counter = 0;

        public static void Recurse()
        {
            counter++;
            if (counter <= MaxRecursiveCalls)
                Recurse();
            else
                throw new StackOverflowException("Detected exception: Stack overflow.");
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
