using System;

namespace OptionSharp
{
    /// <summary>
    /// A base interface for anything that is optional.
    /// </summary>
    public interface IOptional
    {
        /// <summary>
        /// Indicates whether the IOptional has a value or not
        /// </summary>
        bool IsPresent { get; }

    }

    /// <summary>
    /// Interface for a typed optional
    /// </summary>
    /// <typeparam name="T">The type of the optional value</typeparam>
    public interface IOptional<out T> : IOptional
    {
        /// <summary>
        /// Retrieve the optional value
        /// </summary>
        /// <exception cref="OptionalNotPresentException">
        /// Thrown if the optional does not have a value
        /// </exception>
        T Value { get; }

        /// <summary>
        /// Map a function over the value and return an Optional of the result, or an Absent if there is no value
        /// </summary>
        /// <typeparam name="U">The type of the function return value</typeparam>
        /// <param name="func">The function to be mapped</param>
        /// <returns>An Optional containing the result or an Absent.</returns>
        IOptional<U> Map<U>(Func<T, U> func);

        /// <summary>
        /// Map a function with no return value over the value if we have one, and return this Optional unchanged
        /// </summary>
        /// <param name="func">The function to be mapped</param>
        /// <returns>this</returns>
        IOptional<T> MapThrough(Action<T> func);

        /// <summary>
        /// Map a function over the value and return an Optional of the result
        /// </summary>
        /// <typeparam name="U">The type of the function return value</typeparam>
        /// <param name="func">The function to be mapped</param>
        /// <returns>The result of the function</returns>
        IOptional<U> FlatMap<U>(Func<T, IOptional<U>> func);

        /// <summary>
        /// Pattern matching
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="withValue"></param>
        /// <param name="withoutValue"></param>
        /// <returns></returns>
        U Match<U>(Func<T, U> withValue, Func<U> withoutValue);
    }
}