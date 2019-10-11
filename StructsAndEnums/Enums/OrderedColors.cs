using System;
using System.Collections.Generic;
using System.Text;

namespace StructsAndEnums.Enums
{
    public enum Colors
    {
        Red = 5,
        Orange = 8,
        Yellow = 3,
        Green = 1,
        Blue = 7,
        Purple = 2,
        White = 6,
        Pink = 4
    }
    public static class OrderedColors
    {
        public static Array OrderColorsAsc(this Colors color)
        {
            var allcolors = Enum.GetValues(typeof(Colors));
            Array.Sort(allcolors);
            return allcolors;
        }
    }
}
