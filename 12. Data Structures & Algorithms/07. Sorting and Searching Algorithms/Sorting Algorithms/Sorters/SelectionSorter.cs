namespace Algorithms.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int j;

            for (j = 0; j < collection.Count-1; j++)
            {
                int iMin = j;

                int i;
                for (i = 0; i < collection.Count; i++)
                {
                    if (collection[i].CompareTo(collection[iMin]) < 0)
                    {
                        iMin = i;
                    }
                }

                if (iMin != j)
                {
                    this.Swap(collection, j, iMin);
                }
            }
        }

        private void Swap(IList<T> collection, int i, int iMin)
        {
            T swap = collection[i];
            collection[i] = collection[iMin];
            collection[iMin] = swap;
        }
    }
}
