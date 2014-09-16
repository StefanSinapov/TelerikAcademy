namespace _05.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class Program
    {
        public static int counter = 0;
        static void Main()
        {

            var numberOfElements = int.Parse(Console.ReadLine());
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var steps = int.Parse(Console.ReadLine());

            bool isSored = IsSorted(numbers);

            if (isSored)
            {
                Console.WriteLine(0);
                return;
            }




            //            for (int j = 0; j < numbers.Length - 1; j++)
            //            {
            //                int iMin = j;
            //
            //                for (int i = 0; i < numbers.Length; i++)
            //                {
            //                    if (numbers[i].CompareTo(numbers[iMin]) < 0)
            //                    {
            //                        iMin = i;
            //                    }
            //                }
            //                 
            //                if (iMin != j)
            //                {
            //                    counter++;
            //                    Swap(ref numbers, j, iMin);
            //                }
            //            }

            Sort(numbers);

            Console.WriteLine(counter);
        }


        public static void Sort(IList<int> collection)
        {
            int swapIndex = 0;

            for (int i = 0; i < collection.Count - 1; i++)
            {
                swapIndex = i;

                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[swapIndex].CompareTo(collection[j]) > 0)
                    {
                        swapIndex = j;
                    }
                }

                counter++;
                Swap(collection, i, swapIndex);
//                Console.WriteLine("swap: {0}", swapIndex - i);
            }
        }

        private static void Swap(IList<int> collection, int i, int iMin)
        {
            int swap = collection[i];
            collection[i] = collection[iMin];
            collection[iMin] = swap;
        }

        private static bool IsSorted(IList<int> numbers)
        {
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] > numbers[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
