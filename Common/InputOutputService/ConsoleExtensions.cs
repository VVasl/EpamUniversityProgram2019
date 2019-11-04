//-----------------------------------------------------------------------
// <copyright file="ConsoleExtensions.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common.InputOutputService
{
    using System;
    using System.ComponentModel;
    using System.Globalization;

    /// <summary>
    /// An extension method defined for the <see cref="ConsoleInputOutput"/> class.
    /// </summary>
    public static class ConsoleExtensions
    {
        /// <summary>
        /// Reads the string representation of a number from the standard input stream
        /// and converts it to for the specified type.
        /// </summary>
        /// <param name="reader">The string representation of a number from the standard input stream.</param>
        /// <returns> The the specified type of inValue string representation.</returns>
        public static T Read<T>(this ConsoleInputOutput reader)
        {
            string inValue = Console.ReadLine();
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
        }
    }
}
