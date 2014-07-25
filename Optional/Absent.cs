using System;

namespace Optional
{
    class Absent<T> : IOptional<T>
    {
        public bool IsPresent
        {
            get { return false; }
        }

        public T Value
        {
            get { throw new OptionalNotPresentException();  }
        }

        public IOptional<U> Map<U>(Func<T, U> action)
        {
            return Optional.Absent<U>();
        }

        public bool Equals(IOptional other)
        {
            // All absents are equal
            return !other.IsPresent;
        }

        public override bool Equals(object obj)
        {
            if (obj is IOptional)
            {
                return Equals(obj as IOptional);
            }

            return base.Equals(obj);
        }
    }
}