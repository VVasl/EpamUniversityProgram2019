//-----------------------------------------------------------------------
// <copyright file="IReaderGeneric.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common
{
    public interface IReaderGeneric 
    {
        /// <summary>
        /// Reads the next line of characters from the standard input stream.
        /// </summary>
        /// <returns> The next line of characters from the input stream, or null if no more lines are available.</returns>
        T Read<T>() where T : class;
    }
}
