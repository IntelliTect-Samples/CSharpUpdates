﻿using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace EssentialCSharp10;

public static class Verify
{
    /// <summary>
    /// Verifies the <paramref name="argument"/> is not null or empty. If
    /// it is, an <see cref="ArgumentNullException"/> is thrown.
    /// </summary>
    /// <param name="argument">The expression that is checked for null or empty.</param>
    /// <param name="argumentExpression">The caller argument expression used to populate the
    /// message when the argument is null or empty. This value should not be provided as it 
    /// is generated by the compiler.</param>
    /// <returns><paramref name="argument"/> if the value is not null or empty.</returns>
    [DebuggerStepThrough()]
    public static string AssertNotNullOrEmpty(
         string? argument,
        [CallerArgumentExpression("argument")]
            string argumentExpression = null!)
    {
        if(argument is null) throw new ArgumentNullException(nameof(argument));
        if (string.IsNullOrEmpty(argument))
        {
            throw new ArgumentException(
                "Argument cannot be null or empty.", argumentExpression);
        }
        return argument;
    }

    /// <summary>
    /// Asserts the <paramref name="condition"/> is true. If
    /// it is not, an <see cref="ArgumentException"/> is thrown.
    /// </summary>
    /// <param name="condition">The predicate <paramref name="condition"/> that is checked.</param>
    /// <param name="message">The message to populate the expression when the <paramref name="condition"/>
    /// is not true.</param>
    /// <param name="conditionExpression">The caller argument expression used to populate the
    /// message when the <paramref name="condition"/> does not return true. This value should 
    /// not be provided as it is generated by the compiler.</param>
    [DebuggerStepThrough()]
    public static void Argument(
        bool condition, string message,
        [CallerArgumentExpression("condition")] string conditionExpression = null!)
    {
        if (!condition) throw new ArgumentException(message: message, paramName: conditionExpression);
    }

    /// <summary>
    /// Used to verify that <paramref name="argument"/> is within the
    /// ranges specified by <paramref name="low"/> to <paramref name="high"/>.
    /// </summary>
    /// <param name="argument">The argument to check is within the range.</param>
    /// <param name="low">The minimum value allowed for the <paramref name="argument"/>.</param>
    /// <param name="high">The maximum value allowed for the <paramref name="argument"/></param>
    /// <param name="argumentExpression">The caller argument expresson for the 
    /// <paramref name="argument"/> value.</param>
    /// <param name="lowExpression">The caller argument expression for the 
    /// <paramref name="lowExpression"/>. This value should not be provided as it is generated by the compiler.</param>
    /// <param name="highExpression">The caller argument expression for the 
    /// <paramref name="highExpression"/>. This value should not be provided as it is generated by the compiler.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    [DebuggerStepThrough()]
    public static void InRange(int argument, int low, int high,
        [CallerArgumentExpression("argument")] string argumentExpression = null!,
        [CallerArgumentExpression("low")] string lowExpression = null!,
        [CallerArgumentExpression("high")] string highExpression = null!)
    {
        if (argument < low)
        {
            throw new ArgumentOutOfRangeException(paramName: argumentExpression,
                message: $"{argumentExpression} ({argument}) cannot be less than {lowExpression} ({low}).");
        }

        if (argument > high)
        {
            throw new ArgumentOutOfRangeException(paramName: argumentExpression,
                message: $"{argumentExpression} ({argument}) cannot be greater than {highExpression} ({high}).");
        }
    }


    /// <summary>
    /// Verifies that the <paramref name="argument"/> is not null and throws a
    /// <see cref="ArgumentNullException"/> if it is.
    /// </summary>
    /// <typeparam name="T">The Type of the <paramref name="argument"/>.</typeparam>
    /// <param name="argument">The expression to be evaluated for null.</param>
    /// <param name="argumentExpression">The argument expression text. This value should 
    /// not be provided as it is generated by the compiler.</param>
    /// <exception cref="ArgumentNullException"></exception>
    [DebuggerStepThrough()]
    public static T NotNull<T>(T argument, [CallerArgumentExpression("argument")] string argumentExpression = null!)
        where T : class =>
        argument ??throw new ArgumentNullException(paramName: argumentExpression);
}