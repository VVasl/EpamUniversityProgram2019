//-----------------------------------------------------------------------
// <copyright file="IWriter.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common
{
    public interface IWriter
    {
        /// <summary>
        /// Writes the specified data to the standard output stream.
        /// </summary>
        /// <param name="obj">The value parameter.</param>
        void Write(object obj);
    }
}
