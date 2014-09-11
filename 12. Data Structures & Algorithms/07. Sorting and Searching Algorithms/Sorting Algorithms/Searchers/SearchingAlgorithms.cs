namespace Algorithms.Searchers
{
    using System;
    using System.Collections.Generic;

    public static class SearchingAlgorithms
    {
        public static int LinearSearch<T>(this IList<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection cannot be null");
            }
            if (item == null)
            {
                throw new ArgumentNullException("item cannot be null");
            }

            for (int i = 0; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(item) == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch<T>(this IList<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection cannot be null");
            }
            if (item == null)
            {
                throw new ArgumentNullException("item cannot be null");
            }

            int left = 0;
            int right = collection.Count - 1;
            int middle = 0;

            while (left <= right)
            {
                // median
                middle = left + ((right - left) >> 1);
                if (collection[middle].CompareTo(item) < 0)
                {
                    left = middle + 1;
                }
                else if (collection[middle].CompareTo(item) > 0)
                {
                    right = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }
    }
}