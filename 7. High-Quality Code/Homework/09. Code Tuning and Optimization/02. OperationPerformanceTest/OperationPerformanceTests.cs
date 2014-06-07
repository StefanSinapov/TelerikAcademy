namespace OperationPerformanceTest
{
    using System;
    using System.Diagnostics;

    public class OperationPerformanceTests
    {
        private static readonly Stopwatch timer = new Stopwatch();
        private static readonly Random random = new Random();

        private const int Count = 1000000;

        public static void Main()
        {
            PerformIntTest(Count);
            PerformLongTest(Count);
            PerformFloatTest(Count);
            PerformDoubleTest(Count);
            PerformDecimalTest(Count);

        }

        static int GetRandomValue()
        {
            return random.Next(1, int.MaxValue);
        }

        private static void PerformFloatTest(int Count)
        {
            float value = GetRandomValue();
            timer.Reset();
            timer.Start();
            for (int i = 0; i < Count; i++)
            {
                value += GetRandomValue(); // add
                value -= GetRandomValue(); // subtract
                value++; //increment
                value *= GetRandomValue(); // multiply
                value /= GetRandomValue(); // divide
            }

            timer.Stop();
            Console.WriteLine("Float Test - Total Time: " + timer.Elapsed);
        }

        private static void PerformLongTest(int Count)
        {
            long value = GetRandomValue();
            timer.Reset();
            timer.Start();
            for (int i = 0; i < Count; i++)
            {
                value += GetRandomValue(); // add
                value -= GetRandomValue(); // subtract
                value++; //increment
                value *= GetRandomValue(); // multiply
                value /= GetRandomValue(); // divide
            }

            timer.Stop();
            Console.WriteLine("Long Test - Total Time: " + timer.Elapsed);
        }

        private static void PerformIntTest(int Count)
        {
            int value = GetRandomValue();
            timer.Reset();
            timer.Start();
            for (int i = 0; i < Count; i++)
            {
                value += GetRandomValue(); // add
                value -= GetRandomValue(); // subtract
                value++; //increment
                value *= GetRandomValue(); // multiply
                value /= GetRandomValue(); // divide
            }

            timer.Stop();
            Console.WriteLine("Int Test - Total Time: " + timer.Elapsed);
        }

        private static void PerformDecimalTest(int Count)
        {
            decimal value = GetRandomValue();
            timer.Reset();
            timer.Start();
            for (int i = 0; i < Count; i++)
            {
                value += GetRandomValue(); // add
                value -= GetRandomValue(); // subtract
                value++; //increment
                //value *= GetRandomValue(); // multiply
                value /= GetRandomValue(); // divide
            }

            timer.Stop();
            Console.WriteLine("Decimal Test - Total Time: " + timer.Elapsed);
        }

        private static void PerformDoubleTest(int Count)
        {
            double value = GetRandomValue();
            timer.Reset();
            timer.Start();
            for (int i = 0; i < Count; i++)
            {
                value += GetRandomValue(); // add
                value -= GetRandomValue(); // subtract
                value++; //increment
                value *= GetRandomValue(); // multiply
                value /= GetRandomValue(); // divide
            }

            timer.Stop();
            Console.WriteLine("Double Test - Total Time: " + timer.Elapsed);
        }
    }
}
