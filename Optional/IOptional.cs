using System;

namespace Optional
{
    interface IOptional
    {
        bool IsPresent { get; }
    }

    interface IOptional<out T> : IOptional
    {
        T Value { get; }

        IOptional<U> Map<U>(Func<T, U> action);
    }
}