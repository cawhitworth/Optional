using System;
using System.Runtime.CompilerServices;

namespace OptionSharp
{
    /// <summary>
    /// An untyped optional that is always absent
    /// </summary>
    public class Absent : IOptional
    {
        /// <summary>
        /// Absents are never present
        /// </summary>
        public bool IsPresent
        {
            get { return false; }
        }

        /// <summary>
        /// Notionally apply the function over the Absent; this is a hack to make
        /// an Absent behave a bit like an IOptional &lt;T&gt; under some circumstances.
        /// 
        /// Always returns an Absent
        /// </summary>
        /// <typeparam name="T">Ignored</typeparam>
        /// <typeparam name="U">Type of Absent</typeparam>
        /// <param name="func">Function to apply</param>
        /// <returns>Absent &lt;U&gt;</returns>
        public IOptional<U> Map<T, U>(Func<T, U> func)
        {
            return (Absent<U>) Optional.Absent;
        }


        /// <summary>
        /// Notionally apply the function over the Absent; this is a hack to make
        /// an Absent behave a bit like an IOptional &lt;T&gt; under some circumstances.
        /// 
        /// Always returns an Absent; the function is never called
        /// </summary>
        /// <param name="func">Function to apply - this is never called</param>
        /// <returns>Absent &lt;T&gt;</returns>
        public IOptional<T> MapThrough<T>(Action<T> func)
        {
            return (Absent<T>) Optional.Absent;
        }

        /// <summary>
        /// Notionally apply the function over the Absent; this is a hack to make
        /// an Absent behave a bit like an IOptional &lt;T&gt; under some circumstances.
        /// 
        /// Always returns an Absent
        /// </summary>
        /// <typeparam name="T">Ignored</typeparam>
        /// <typeparam name="U">Type of Absent</typeparam>
        /// <param name="func">Function to apply</param>
        /// <returns>Absent &lt;U&gt;</returns>
        public IOptional<U> FlatMap<T, U>(Func<T, IOptional<U>> func)
        {
            return (Absent<U>) Optional.Absent;
        }

        /// <summary>
        /// Pattern matching: will always execute and return the result of withoutValue
        /// </summary>
        /// <typeparam name="T">Ignored</typeparam>
        /// <typeparam name="U">Return type of withoutValue</typeparam>
        /// <param name="withValue">Ignored</param>
        /// <param name="withoutValue">Will be executed and its result returned</param>
        /// <returns></returns>
        public U Match<T, U>(Func<T, U> withValue, Func<U> withoutValue)
        {
            return withoutValue();
        }

        /// <summary>
        /// Tests for equality against another <see cref="IOptional"/>.
        /// </summary>
        /// <param name="other">The other <see cref="IOptional"/></param>
        /// <returns>True if the other <see cref="IOptional"/> is not present, and false otherwise</returns>
        public bool Equals(IOptional other)
        {
            // All absents are equal
            return !other.IsPresent;
        }

        /// <summary>
        /// Tests for equality against another object.
        /// </summary>
        /// <param name="other">The other object</param>
        /// <returns>True if the other object is an <see cref="IOptional"/> that is not present, and false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj is IOptional)
            {
                return Equals(obj as IOptional);
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// String conversion
        /// </summary>
        /// <returns>"Absent"</returns>
        public override string ToString()
        {
            return "Absent";
        }

        /// <summary>
        /// Hash code
        /// </summary>
        /// <returns>0</returns>
        public override int GetHashCode()
        {
            return 0;
        }
    }

    /// <summary>
    /// An Optional that is always absent
    /// </summary>
    /// <typeparam name="T">The type that is absent</typeparam>
    public class Absent<T> : IOptional<T>
    {
        /// <summary>
        /// The only way to construct a typed Absent is to construct an untyped and cast it.
        /// </summary>
        private Absent() { }

        public static implicit operator Absent<T>(Absent a)
        {
            return new Absent<T>();
        }

        /// <summary>
        /// Always false, as an Absent never has a value
        /// </summary>
        public bool IsPresent
        {
            get { return false; }
        }

        /// <summary>
        /// Always throws <see cref="OptionalNotPresentException"/>
        /// </summary>
        /// <exception cref="OptionalNotPresentException">
        /// An Absent never has a value.
        /// </exception>
        public T Value
        {
            get { throw new OptionalNotPresentException();  }
        }

        /// <summary>
        /// Will always return an Absent - the function will never be executed.
        /// </summary>
        /// <typeparam name="U">The type of the function return value</typeparam>
        /// <param name="func">The function to be mapped - never executed for an Absent</param>
        /// <returns>An Absent &lt; U &gt;.</returns>
        public IOptional<U> Map<U>(Func<T, U> func)
        {
            return (Absent<U>) Optional.Absent;
        }

        /// <summary>
        /// Always return an Absent - the function will never be executed
        /// </summary>
        /// <param name="func">The function to be mapped - never executed for an Absent</param>
        /// <returns>An Absent &lt; T &gt;</returns>
        public IOptional<T> MapThrough(Action<T> func)
        {
            return (Absent<T>) Optional.Absent;
        }

        /// <summary>
        /// Will always return an Absent - the function will never be executed.
        /// </summary>
        /// <typeparam name="U">The type of the function return value</typeparam>
        /// <param name="func">The function to be mapped - never executed for an Absent</param>
        /// <returns>An Absent &lt; U &gt;.</returns>
        public IOptional<U> FlatMap<U>(Func<T, IOptional<U>> func)
        {
            return (Absent<U>) Optional.Absent;
        }

        /// <summary>
        /// Pattern matching: will always execute and return the result of withoutValue
        /// </summary>
        /// <typeparam name="U">Return type of withoutValue</typeparam>
        /// <param name="withValue">Ignored</param>
        /// <param name="withoutValue">Function to execute</param>
        /// <returns>Result of executing withoutValue</returns>
        public U Match<U>(Func<T, U> withValue, Func<U> withoutValue)
        {
            return withoutValue();
        }

        /// <summary>
        /// Tests for equality against another <see cref="IOptional"/>.
        /// </summary>
        /// <param name="other">The other <see cref="IOptional"/></param>
        /// <returns>True if the other <see cref="IOptional"/> is not present, and false otherwise</returns>
        public bool Equals(IOptional other)
        {
            // All absents are equal
            return !other.IsPresent;
        }

        /// <summary>
        /// Tests for equality against another object.
        /// </summary>
        /// <param name="other">The other object</param>
        /// <returns>True if the other object is an <see cref="IOptional"/> that is not present, and false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj is IOptional)
            {
                return Equals(obj as IOptional);
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// String conversion
        /// </summary>
        /// <returns>Absent</returns>
        public override string ToString()
        {
            return "Absent";
        }

        /// <summary>
        /// Hash code
        /// </summary>
        /// <returns>0</returns>
        public override int GetHashCode()
        {
            return 0;
        }
    }
}