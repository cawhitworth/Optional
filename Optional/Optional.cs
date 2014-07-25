using System;

namespace Optional
{
    class Optional<T> : IOptional<T>
    {
        private T v;

        public Optional(T v)
        {
            this.v = v;
        }

        public T Value { get { return v; } }

        public IOptional<U> Map<U>(Func<T, U> action)
        {
            if (IsPresent)
            {
                return Optional.Of(action(Value));
            }
            else
            {
                return Optional.Absent<U>();
            }
        }

        public bool IsPresent { get { return true; }}

        public bool Equals(IOptional<T> other)
        {
            if (other.IsPresent)
            {
                return other.Value.Equals(Value);
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj is IOptional<T>)
            {
                return Equals(obj as IOptional<T>);
            }

            return false;
        }
    }

    class Optional
    {
        private static IOptional<object> absent = new Absent<object>();

        public static IOptional<T> Of<T>(T t)
        {
            return new Optional<T>(t);
        }

        public static IOptional<T> Absent<T>()
        {
            return new Absent<T>();
        }

        public static IOptional<object> Absent()
        {
            return absent;
        }
    }
}