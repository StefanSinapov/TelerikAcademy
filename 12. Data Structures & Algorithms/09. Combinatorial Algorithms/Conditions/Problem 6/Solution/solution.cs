using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficialSumSubSeq
{
    public class Sums
    {
        public static long CalculateBinom(int n, int k)
        {
            long nominator = 1;
            for (int i = n; i >= (n - k + 1); i--)
            {
                nominator *= i;
            }

            long denominator = 1;
            for (int i = k; i >= 1; i--)
            {
                denominator *= i;
            }

            return (nominator / denominator);
        }

        public static long CalculateSum(int[] numbers)
        {
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        public static void ReadInputAndSolve()
        {
            int tests = int.Parse(Console.ReadLine());
            for (int i = 0; i < tests; i++)
            {
                string[] nAndKValues = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                short n = short.Parse(nAndKValues[0]);
                short k = short.Parse(nAndKValues[1]);
                int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

                Console.WriteLine(SolveSumSubSeq(n, k, numbers));
            }
        }

        public static long SolveSumSubSeq(int n, int k, int[] numbers)
        {
            long sumSubSeq = CalculateBinom(n - 1, k) * CalculateSum(numbers);
            return sumSubSeq;
        }

        static void Main(string[] args)
        {
            ReadInputAndSolve();
        }
    }
}
