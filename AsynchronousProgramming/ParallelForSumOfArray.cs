namespace AsynchronousProgramming
{
    using System.Threading.Tasks;

    public class ParallelForSumOfArray : ISum
    {
        public int SumUpTwoDimensionalArray(int[,] arr)
        {
            int total = 0;
            int parts = 4;
            int partSize = arr.GetLength(0) / parts;
            var parallel = Parallel.For(0, parts,
                localInit: () => 0, 
                body: (iter, state, localTotal) =>
                {
                    for (int j = iter * partSize; j < (iter + 1) * partSize; j++)
                    {
                        for (int k = 0; k < arr.GetLength(1); k++)
                            localTotal += arr[j,k];
                    }

                    return localTotal;
                },
                localFinally: (localTotal) => { total += localTotal; });
            return total;
        }
    }
}
