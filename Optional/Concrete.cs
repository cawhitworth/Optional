using System;

namespace Optional
{
    /// <summary>
    /// An Optional that has a value
    /// </summary>
    /// <typeparam name="T">The type of the value</typeparam>
    class Concrete<T> : IOptional<T>
    {
        private readonly T _value;

        public Concrete(T value)
        {
            _value = value;
        }

        /// <summary>
        /// Return the value of this Concrete
        /// </summary>
        public T Value { get { return _value; } }

        /// <summary>
        /// Apply the function 'func' to Value and return an Optional of the result
        /// </summary>
        /// <typeparam name="U">Return type of func</typeparam>
        /// <param name="func">Function to apply</param>
        /// <returns>An Optional of the result of applying the function to Value</returns>
        public IOptional<U> Map<U>(Func<T, U> func)
        {
            return Optional.Of(func(Value));
        }

        /// <summary>
        /// Apply the function 'func' to Value and return the result
        /// </summary>
        /// <typeparam name="U">Type of the Optional returned by func</typeparam>
        /// <param name="func">Function to apply</param>
        /// <returns>The result of applying the function to Value</returns>
        public IOptional<U> FlatMap<U>(Func<T, IOptional<U>> func)
        {
            return func(Value);
        }

        /// <summary>
        /// Pattern matching: executes withValue with Value and returns the result
        /// </summary>
        /// <typeparam name="U">Return type of withValue</typeparam>
        /// <param name="withValue">Function to execute</param>
        /// <param name="withoutValue">Ignored</param>
        /// <returns>Result of calling withValue</returns>
        public U Match<U>(Func<T, U> withValue, Func<U> withoutValue)
        {
            return withValue(Value);
        }

        /// <summary>
        /// Always true for a Concrete
        /// </summary>
        public bool IsPresent { get { return true; }}

        /// <summary>
        /// Equality test against another Optional of the same type
        /// </summary>
        /// <param name="other">Another Optional</param>
        /// <returns>True if the other optional has the same Value; false otherwise</returns>
        public bool Equals(IOptional<T> other)
        {
            if (other.IsPresent)
            {
                return other.Value.Equals(Value);
            }

            return false;
        }

        /// <summary>
        /// Equality test against any object
        /// </summary>
        /// <param name="obj">Another object</param>
        /// <returns>True if the other object is an Optional of the same type with the same Value; false otherwise</returns>
        public override bool Equals(object obj)
        {
            if (obj is IOptional<T>)
            {
                return Equals(obj as IOptional<T>);
            }

            return false;
        }

        /// <summary>
        /// String conversion
        /// </summary>
        /// <returns>"Concrete &lt;Value&gt;"</returns>
        public override string ToString()
        {
            return String.Format("Concrete {0}", Value);
        }

        /// <summary>
        /// Hash Code
        /// </summary>
        /// <returns>Value.GetHashCode()</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}