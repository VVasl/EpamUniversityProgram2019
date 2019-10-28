using Exceptions;
using Logger;

namespace DumpLogger
{
    static class Program
    {
        static void Main(string[] args)
        {
            MyLogger logger = new MyLogger();
            logger.Info("\n-----Task2-----IndexOutOfRangeException\n\n", Operation.LoggingToConsole);

            int n = 7;

            try
            {
                ExceptionSituations.InstantiateArray(n, 100);
            }
            catch (System.IndexOutOfRangeException e)
            {
                logger.Error(e.Message, Operation.LoggingToConsole);
            }
            catch (System.Exception e)
            {
                logger.Error(e.Message, Operation.LoggingToFile);
                logger.ReadFromLogFile();
            }
        }
    }
}
