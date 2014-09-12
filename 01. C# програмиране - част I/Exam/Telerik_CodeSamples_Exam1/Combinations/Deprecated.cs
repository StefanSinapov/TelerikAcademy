using System;
using System.Collections.Generic;

class Combinations
{
    static List<int> counterKeeper = new List<int>();

    static void Combine(int[] arr, int cycleUntil = 2, int startFrom = 0)
    {
        if (cycleUntil < arr.Length)
        {
            Console.WriteLine("for(int ct = {0}; ct < {1}; ct++)", startFrom, cycleUntil);

            for (int ct = startFrom; ct < cycleUntil; ct++)
            {
                counterKeeper.Add(ct);
                //Console.Write(ct + "; ");
                Combine(arr, cycleUntil + 1, ct + 1);
            }
        }
        else
        {
            /*
            string shit = String.Empty;

            foreach (int startPoint in counterKeeper)
            {
                shit += arr[startPoint] + " ";
            }

            Console.Write(shit + "\n");

            counterKeeper.Clear();
             * */
        }

    }

    static void Main()
    {
        int[] testArray = {2, 4, 6, 8};

        Combine(testArray);
    }
}