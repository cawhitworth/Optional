using System;

namespace Optional
{
    /// <summary>
    /// Exception thrown when trying to retrieve the Value of an Optional with no Value
    /// </summary>
    internal class OptionalNotPresentException : Exception
    {
    }
}