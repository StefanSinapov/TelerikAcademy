namespace LoopRefactoring
{
    using System;
    using System.Linq;

    public class LoopRefactoringDemo
    {
        public static void Main()
        {
            int[] collection = { 1, 2, 3, 3, 3, 4, 5, 2 };
            int valueToSearchFor = 4;
            bool isFound = false;
            for (int i = 0; i < collection.Length; i++)
            {
                if (i % 10 == 0 && collection[i] == valueToSearchFor)
                {
                    isFound = true;
                }

                Console.WriteLine(collection[i]);
            }

            //// More code here

            if (isFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
