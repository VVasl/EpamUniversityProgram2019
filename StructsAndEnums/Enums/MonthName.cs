
namespace StructsAndEnums.Enums
{
    using System;
    public enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    public static class MonthName
    {
        public static string GetMonth(int n)
        {
            if (!Enum.IsDefined(typeof(Months), n))
                throw new ArgumentOutOfRangeException(
                      $"Value must be between 1 and 12 inclusive.");

            Months month = (Months)n;

            return month.ToString();
        }
    }
}
