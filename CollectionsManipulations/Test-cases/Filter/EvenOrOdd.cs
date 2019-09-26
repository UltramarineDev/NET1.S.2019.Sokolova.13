using CollectionsManipulations.Interfaces;

namespace CollectionsManipulations.Test_cases.Transform
{
    /// <summary>
    /// Class EvenOrOdd with implementation of IPredicate interface
    /// </summary>
    public class EvenOrOdd<TSource> : IPredicate<int>
    {
        /// <summary>
        /// Method determines if number is even or odd
        /// </summary>
        /// <param name="value">input number</param>
        /// <returns>true if number is even and false - if odd</returns>
        public bool IsPredicate(int value)
        {
            return value % 2 == 0;
        }
    }
}
