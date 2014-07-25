namespace Optional
{
    /// <summary>
    /// Helper class for constructing Optionals
    /// </summary>
    class Optional
    {
        private static Absent absent = new Absent();

        /// <summary>
        /// Construct a Concrete Optional of type T
        /// </summary>
        /// <typeparam name="T">Type of Optional</typeparam>
        /// <param name="v">Value</param>
        /// <returns>The constructed Concrete</returns>
        public static IOptional<T> Of<T>(T v)
        {
            return new Concrete<T>(v);
        }

        /// <summary>
        /// An untyped Absent
        /// </summary>
        public static Absent Absent
        {
            get { return absent; }
        }

        /// <summary>
        /// A typed Absent
        /// </summary>
        /// <typeparam name="T">Type of Absent</typeparam>
        /// <returns>An Absent of type T</returns>
        public static Absent<T> AbsentOf<T>()
        {
            return absent;
        }
    }
}