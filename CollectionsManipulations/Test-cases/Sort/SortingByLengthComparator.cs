using System.Collections.Generic;

namespace Test_cases.Sort
{
    /// <summary>
    /// Class SortingByLengthComparator with implementation of IComparer interface
    /// </summary>
    public class SortingByLengthComparator<TSource> : IComparer<string>
    {
        /// <summary>
        /// Method compares length two strings
        /// </summary>
        /// <param name="first">first string</param>
        /// <param name="second">second string</param>
        /// <returns>integer value</returns>
        public int Compare(string first, string second)
        {
            if (first.Length == second.Length)
            {
                return 0;
            }

            return first.Length > second.Length ? 1 : -1;
        }
    }
}
