//-----------------------------------------------------------------------
// <copyright file="IShowMemberInfo.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common
{
    public interface IShowMemberInfo 
    {
        /// <summary>
        /// Writes the specified data to the standard output stream.
        /// </summary>
        /// <param name="indent">The number of indents.</param>
        /// <param name="format">Set the string representation format of a specified object.</param>
        /// <param name="args">The object to format.</param>
        void Show(int indent, string format, params object[] args);
    }
}
