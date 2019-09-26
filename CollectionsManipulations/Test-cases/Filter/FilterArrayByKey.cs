using CollectionsManipulations.Interfaces;
using System;

namespace CollectionsManipulations.Test_cases.Transform
{
    /// <summary>
    /// Class FilterArrayByKey with implementation of IPredicate interface
    /// </summary>
    public class FilterArrayByKey<TSource> : IPredicate<int>
    {
        private int key;

        /// <summary>
        /// Initializes a new instance of the FilterArrayByKey class
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if key value in invalid</exception>     
        public FilterArrayByKey(int key)
        {
            Key = key;
        }

        /// <summary>
        /// Gets or sets the value of key
        /// </summary>
        public int Key
        {
            get
            {
                return key;
            }

            set
            {
                if (value > 9 || value < 0)
                {
                    throw new ArgumentException(" Input number is not a digit.", nameof(Key));
                }

                key = value;
            }
        }

        /// <summary>
        /// Method determines if number contains key value or not
        /// </summary>
        /// <param name="value">input number</param>
        /// <returns>true if number contains key, false - if not</returns>
        public bool IsPredicate(int value)
        {
            while (value != 0)
            {
                if (Math.Abs(value % 10) == Key)
                {
                    return true;
                }

                value = value / 10;
            }

            return false;
        }
    }
}
