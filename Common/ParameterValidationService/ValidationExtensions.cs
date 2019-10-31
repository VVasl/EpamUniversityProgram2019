//-----------------------------------------------------------------------
// <copyright file="ValidationExtensions.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common
{
    using System;
    using System.Collections;

    public static class ValidationExtensions
    {
        /// <summary>
        /// Check if the specified <paramref name="value"/> is null or empty.
        /// </summary>
        /// <typeparam name="T">The element type of the <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <returns>true if the <paramref name="value"/> is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty<T>(this T value)
        {
            if (value == null)
            {
                return true;
            }

            var collection = value as IEnumerable;

            foreach (var v in collection)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if the specified <paramref name="value"/> is null or empty.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>true if the <paramref name="value"/> is null or empty; otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }
        
        /// <summary>
        /// Check if the specified <paramref name="value"/> is greater than <paramref name="min"/>.
        /// </summary>
        /// <typeparam name="T">The element type of the values to compare.</typeparam>
        /// <param name="value">The value to check.</param>
        /// <param name="min">The min value.</param>
        /// <returns>true if the <paramref name="value"/> is greater than <paramref name="min"/>; otherwise, false.</returns>
        public static bool IsGreaterThan<T>(this T value, T min) where T : IComparable<T>
        {
            ParameterValidation.AssertNotNull(value, nameof(value));
            return value.CompareTo(min) > 0;
        }
    }
}
