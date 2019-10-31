//-----------------------------------------------------------------------
// <copyright file="ParameterValidation.cs" company="Epam Lab">
// Copyright (c) Epam Lab. All rights reserved.
// </copyright>
// <author>Vasyltsiv Viktoriia</author>
//-----------------------------------------------------------------------
namespace Common
{
    using System;

    /// <summary>
    /// Provides methods to validate argument parameters.
    /// </summary>
    public static class ParameterValidation
    {
            /// <summary>
            /// Throw a <see cref="ArgumentNullException"/> if <paramref name="paramValue"/> is null.
            /// </summary>
            /// <typeparam name="T">The type of <paramref name="paramValue"/>.</typeparam>
            /// <param name="paramValue">The value parameter.</param>
            /// <param name="paramName">The name of the parameter.</param>
            public static void AssertNotNull<T>(T paramValue, string paramName = null)
            {
                if (paramValue == null)
                {
                    throw new ArgumentNullException(paramName);
                }
            }

            /// <summary>
            /// Throw a <see cref="ArgumentException"/> if <paramref name="paramValue"/> is null or empty.
            /// For Non-Null types, check if <paramref name="paramValue"/> equals the type default value.
            /// For Null types, check if <paramref name="paramValue"/>.Value equals the type default value.
            /// </summary>
            /// <typeparam name="T">The type of <paramref name="paramValue"/>.</typeparam>
            /// <param name="paramValue">The value parameter.</param>
            /// <param name="paramName">The name of the parameter.</param>
            public static void AssertNotNullOrEmpty<T>(T paramValue, string paramName = null)
            {
                    if (!paramValue.IsNullOrEmpty())
                    {
                        return;
                    }
                
                    if (paramName == null)
                    {
                        throw new ArgumentException("The argument must not be empty.");
                    }
               
                    throw new ArgumentException("The argument must not be empty.", paramName); 
            }

            /// <summary>
            /// Throw a <see cref="ArgumentOutOfRangeException"/> if <paramref name="paramValue"/> is not greater than <paramref name="minValue"/>.
            /// </summary>
            /// <typeparam name="T">The type of <paramref name="paramValue"/>.</typeparam>
            /// <param name="paramValue">The value parameter.</param>
            /// <param name="minValue">The min value to compare to <paramref name="paramValue"/>.</param>
            /// <param name="paramName">The name of the parameter.</param>
            public static void AssertGreaterThan<T>(T paramValue, T minValue, string paramName = null)
                where T : IComparable<T>
            {
                if (paramValue.IsGreaterThan(minValue))
                {
                    return;
                }
                
                if (paramName == null)
                {
                    throw new ArgumentOutOfRangeException($"The argument is smaller than/equal to minimum of '{minValue}'");
                }
                   
                throw new ArgumentOutOfRangeException(paramName,
                               $"The argument '{paramName}' is smaller than/equal to minimum of '{minValue}'");
            }
    }
}
