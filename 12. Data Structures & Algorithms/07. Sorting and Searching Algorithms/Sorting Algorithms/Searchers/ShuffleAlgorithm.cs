namespace Algorithms.Searchers
{
    using System;
    using System.Collections.Generic;

    public static class ShuffleAlgorithm
    {
        private static readonly Random random = new Random();

        public static void Shuffle<T>(this IList<T> collection)
        {
            if (collection == null)
            {
                throw new NullReferenceException("Collection cannot be null");
            }

            for (int i = 0; i < collection.Count; i++)
            {
                int j = random.Next(i, collection.Count);
                Swap(collection, j, i);
            }
        }

        private static void Swap<T>(IList<T> collection, int j, int i)
        {
            T swap = collection[i];
            collection[i] = collection[j];
            collection[j] = swap;
        }
    }
}