﻿using CollectionsManipulations.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CollectionManipulations.Test_cases.Transform
{
    /// <summary>
    /// abstract class Transformer
    /// </summary>
    public abstract class Transformer<TSource, TResult> : ITransformer<double, string>
    {
        /// <summary>
        /// Method of Transforming double
        /// </summary>
        /// <param name="number">input double</param>
        /// <returns>string representation</returns>
        public string TransformValue(double number)
        {
            Dictionary<double, string> specialCases = GetSpecialDoubles();

            if (specialCases.TryGetValue(number, out string result))
            {
                return result;
            }

            Dictionary<char, string> words = GetWords();

            return GetResultWord(number, words);
        }

        protected abstract Dictionary<char, string> GetWords();

        protected abstract Dictionary<double, string> GetSpecialDoubles();

        private static string GetResultWord(double number, Dictionary<char, string> dictionary)
        {
            string numberString = number.ToString(CultureInfo.InvariantCulture);
            var resultString = new StringBuilder();

            foreach (var s in numberString)
            {
                resultString.Append($"{dictionary[s]} ");
            }

            return resultString.ToString().TrimEnd();
        }
    }
}
