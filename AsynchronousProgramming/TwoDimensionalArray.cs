namespace AsynchronousProgramming
{
    using System;

    public class TwoDimensionalArray
    {
        private int rows;
        private int columns;

        public TwoDimensionalArray(int rows, int columns, ISum sum)
        {
            this.rows = rows;
            this.columns = columns;
            Array = FillArray();
            Sum = sum;
        }

        public int[,] Array { get; set; }
        public ISum Sum {private get; set; }

        public int[,] FillArray()
        {
            Random rnd = new Random();
            int[,] array = new int[this.rows, this.columns];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(1, 10);
                }
            }

            return array;
        }

        public int SumOfArrayElements()
        {
            return Sum.SumUpTwoDimensionalArray(this.Array);
        }

        public void Display(int sum)
        {
            Console.WriteLine($"Sum of array elements: {sum}\n");
        }
    }
}
