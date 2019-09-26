using CollectionsManipulations.Interfaces;
using System;
using System.Collections.Generic;

namespace CollectionsManipulations
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Method filters sequence using condition
        /// </summary>
        /// <param name="source">input sequence</param>
        /// <param name="predicate">instance of IPredicate interface</param>
        /// <returns>sequence with numbers satisfying condition</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when sequence is null</exception>
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source array can not be null.");
            }

            foreach (var item in source)
            {
                if (predicate.IsPredicate(item))
                {
                    yield return item;
                }
            }
        }
 
        /// <summary>
        /// Method transform source sequence according to input condition
        /// </summary>
        /// <param name="source">sequence</param>
        /// <param name="transformer">parameter of type ITransformer</param>
        /// <returns>transformed sequence</returns>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> transformer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source array can not be null.");
            }

            foreach (var item in source)
            {
                yield return transformer.TransformValue(item);
            }
        }

        /// <summary>
        /// Method sorts sequence using condition
        /// </summary>
        /// <param name="source">input sequence</param>
        /// <param name="comparer">instance of IComparer</param>
        /// <returns>sorted sequence</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when array is null</exception>
        public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source array can not be null.");
            }

            List<TSource> listSource = new List<TSource>(source);
            
            bool swapped = true;
            while (swapped)
            {
                swapped = false;

                int i = 0;
                while (i < listSource.Count - 1)
                {
                    if (comparer.Compare(listSource[i], listSource[i + 1]) > 0)
                    {
                        TSource temp = listSource[i];
                        listSource[i] = listSource[i + 1];
                        listSource[i + 1] = temp;
                        swapped = true;
                    }

                    i++;
                }
            }

            return listSource;
        }
    }
}
