namespace CodeRefactoring
{
    using System;
    using System.Linq;

    public class CodeRefactoringDemo
    {
        public static void Main(string[] args)
        {
            double[] numbers = { 25, 30, 4, 888, 111 };
            int count = numbers.Length;
            Print printer = new Print();
            printer.PrintStatistics(numbers, count);
        }
    }
}
