using System;

namespace Exceptions
{
    public class ExceptionSituations
    {
        public static void Recurse(int remaining)
        {
            if (remaining <= 0)
            {
                return;
            }
            Recurse(remaining - 1);
        }

        public static void WriteArray(int n)
        {
            int[] array = new int[n];

            for (int i = 0; i <= array.Length; i++)
            {
                Console.WriteLine(array[i]);
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
