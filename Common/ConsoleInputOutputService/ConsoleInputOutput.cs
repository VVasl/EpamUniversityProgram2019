//-----------------------------------------------------------------------
// <copyright file="ConsoleInputOutput.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common
{
    using System;

    public class ConsoleInputOutput : IReader, IWriter 
    {
        /// <summary>
        /// Writes the specified data to the standard output stream.
        /// </summary>
        /// <param name="line">The value parameter.</param>
        public void Write(string line)
        {
            Console.WriteLine(line);
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
    }
}
