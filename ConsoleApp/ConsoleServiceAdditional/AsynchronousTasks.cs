namespace ConsoleApp 
{
    using System;
    using AsynchronousProgramming;
    using System.Diagnostics;
    class AsynchronousTasks : Tasks
    {
        public void RunSequentialSumOfArrayTask()
        {
            try
            {
                TwoDimensionalArray array = new TwoDimensionalArray(10000, 10000, new SequentialSumOfArray());
                var watch = Stopwatch.StartNew();
                int sum = array.SumOfArrayElements();
                watch.Stop();
                this.writer.Write($"Regular Iteration. Time Taken-->{watch.ElapsedMilliseconds}");
                array.Display(sum);
            }

            catch (OutOfMemoryException e)
            {
                logger.Error($"Out of Memory: {e.Message}");
            }
        }

        public void RunParallelForTask()
        {
            try
            {
                TwoDimensionalArray array = new TwoDimensionalArray(10000, 10000, new ParallelForSumOfArray());
                var watch = Stopwatch.StartNew();
                int sum = array.SumOfArrayElements();
                watch.Stop();
                this.writer.Write($"Parallel.For with local thread totals. Time Taken-->{watch.ElapsedMilliseconds}");
                array.Display(sum);
            }

            catch (OutOfMemoryException e)
            {
                logger.Error($"Out of Memory: {e.Message}");
            }
        }
    }
}
