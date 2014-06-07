/*
 * 3. Write a program to compare the performance of square root,
 * natural logarithm, sinus for float, double and decimal values.
 */

namespace MathFunctionPerformanceTest
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class MathFunctionPerformanceTest
    {
        private static readonly Stopwatch stopWatch = new Stopwatch();
        private static readonly Random random = new Random();

        private const int Count = 1000000;
        private const int SquareRootPower = 2;

        public static void Main()
        {
            PerformFloatTest(Count, SquareRootPower);
            PerformDoubleTest(Count, SquareRootPower);
            PerformDecimalTest(Count, SquareRootPower);
        }

        static double GetRandomNumber()
        {
            var randomDouble = random.NextDouble() * random.Next(1, int.MaxValue);
            return randomDouble;    
        }

        private static void PerformDecimalTest(int Count, int SquareRootPower)
        {
            decimal value = 0M;
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < Count; i++)
            {
                value = (decimal)Math.Sin(GetRandomNumber()); // Sin
                value = (decimal)Math.Pow(GetRandomNumber(), SquareRootPower); // Square root
                value = (decimal)Math.Log(GetRandomNumber()); //Log
            }

            stopWatch.Stop();
            Console.WriteLine("Decimal Test - Total time: {0}", stopWatch.Elapsed);
        }

        private static void PerformDoubleTest(int Count, int SquareRootPower)
        {
            double value = 0d;
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < Count; i++)
            {
                value = Math.Sin(GetRandomNumber()); // Sin
                value = Math.Pow(GetRandomNumber(), SquareRootPower); // Square root
                value = Math.Log(GetRandomNumber()); //Log
            }

            stopWatch.Stop();
            Console.WriteLine("Double Test - Total time: {0}", stopWatch.Elapsed);
        }

        private static void PerformFloatTest(int Count, int SquareRootPower)
        {
            float value = 0f;
            stopWatch.Reset();
            stopWatch.Start();
            for (int i = 0; i < Count; i++)
            {
                value = (float)Math.Sin(GetRandomNumber()); // Sin
                value = (float)Math.Pow(GetRandomNumber(), SquareRootPower); // Square root
                value = (float)Math.Log(GetRandomNumber()); //Log
            }

            stopWatch.Stop();
            Console.WriteLine("Float Test - Total time: {0}", stopWatch.Elapsed);
        }
    }
}
