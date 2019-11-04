//-----------------------------------------------------------------------
// <copyright file="ConsoleInputOutput.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common
{
    using System;

    public class ConsoleInputOutput : IInputOutput, IShowMemberInfo
    {
        /// <summary>
        /// Writes the specified data to the standard output stream.
        /// </summary>
        /// <param name="obj">The value parameter.</param>
        public void Write(object obj)
        {
            Console.WriteLine(obj);
        }

        /// <summary>
        /// Writes the specified data to the standard output stream.
        /// </summary>
        /// <param name="objects">The value parameter.</param>
        public void Write(params object[] objects)
        {
            foreach (var obj in objects)
            {
                Console.WriteLine(obj);
            }
        }

        /// <summary>
        /// Writes the specified data to the standard output stream.
        /// </summary>
        /// <param name="indent">The number of indents.</param>
        /// <param name="format">Set the string representation format of a specified object.</param>
        /// <param name="args">The object to format.</param>
        public void Show(int indent, string format, params object[] args)
        {
            Console.WriteLine(new string(' ', 3 * indent) + format, args);
        }

        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns> The next line of characters from the input stream, or null if no more lines are available.</returns>
        public string Read()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Reads the string representation of a number from the standard input stream
        /// and converts it to its 32-bit signed integer equivalent .
        /// </summary>
        /// <returns> The 32-bit signed integer equivalent of the number string representation.</returns>
        public int ReadInt32()
        {
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                throw new FormatException($"Unable to parse '{nameof(number)}'");
            }

            return number;
        }

        /// <summary>
        /// Reads the string representation of a number from the standard input stream
        /// and converts it to its double equivalent .
        /// </summary>
        /// <returns> The double equivalent of the number string representation.</returns>
        public double ReadDouble()
        {
            if (!double.TryParse(Console.ReadLine(), out double number))
            {
                throw new FormatException($"Unable to parse '{nameof(number)}'");
            }

            return number;
        }
    }
}
