namespace AsynchronousProgramming
{
    public class SequentialSumOfArray : ISum
    {
        public int SumUpTwoDimensionalArray(int[,] array)
        {
            int total = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    total += array[i, j];

            return total;
        }
    }
}
