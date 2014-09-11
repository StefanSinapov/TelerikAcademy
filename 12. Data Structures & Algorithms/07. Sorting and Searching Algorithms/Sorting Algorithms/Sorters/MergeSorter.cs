﻿namespace Algorithms.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private T[] temp;

        public void Sort(IList<T> collection)
        {

            this.temp = new T[collection.Count];
            this.Partitioning(collection, 0, collection.Count - 1);
        }

        private void Partitioning(IList<T> collection, int leftIndex, int rightIndex)
        {
            if (leftIndex >= rightIndex) return;

            int middleIndex = (leftIndex + rightIndex) / 2;

            this.Partitioning(collection, leftIndex, middleIndex);
            this.Partitioning(collection, middleIndex + 1, rightIndex);

            this.Merge(collection, leftIndex, middleIndex, rightIndex);
        }

        private void Merge(IList<T> collection, int leftIndex, int middleIndex, int rightIndex)
        {
            int tempPointer = leftIndex; // using for T[] 'temp' array
            int leftPointer = leftIndex, rightPointer = middleIndex + 1;

            while (leftPointer <= middleIndex && rightPointer <= rightIndex)
            {
                if (collection[leftPointer].CompareTo(collection[rightPointer]) < 0)
                {
                    temp[tempPointer++] = collection[leftPointer++];
                }
                else
                {
                    temp[tempPointer++] = collection[rightPointer++];
                }
            }

            while (leftPointer <= middleIndex)
            {
                temp[tempPointer++] = collection[leftPointer++];
            }

            while (rightPointer <= rightIndex)
            {
                temp[tempPointer++] = collection[rightPointer++];
            }

            for (int index = leftIndex; index <= rightIndex; index++)
            {
                collection[index] = temp[index];
            }
        }
    }
}
