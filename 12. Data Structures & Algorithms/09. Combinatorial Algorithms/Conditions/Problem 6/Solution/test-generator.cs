using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumSubSeqTestGenerator
{
    public class Generator
    {
        private const int MaxTestsInSingleTestCount = 10;

        //public static void GenerateMaxText(int testsCount)
        //{
        //    StreamWriter writer = new StreamWriter("test.010.in.txt", true);
        //    Random randForN = new Random();
        //    Random randForK = new Random();
        //    Random randForNumbers = new Random();
        //    using (writer)
        //    {
        //        writer.WriteLine(testsCount);
        //        writer.WriteLine("999 5");
        //        StringBuilder numbers = new StringBuilder();
        //        numbers.Append(999);
        //        for (int i = 0; i < 998; i++)
        //        {
        //            numbers.AppendFormat(" {0}", 999);
        //        }
        //        writer.WriteLine(numbers);


        //        for (int i = 0; i < testsCount - 1; i++)
        //        {
        //            numbers = new StringBuilder();
        //            int randN = randForN.Next(1, 1000);
        //            int randK;
        //            if (randN <= 5)
        //            {
        //                randK = randForK.Next(randN);
        //            }
        //            else
        //            {
        //                randK = randForK.Next(6);
        //            }

        //            writer.WriteLine("{0} {1}", randN, randK);

        //            numbers.Append(randForNumbers.Next(-999, 1000));
        //            for (int j = 0; j < randN - 1; j++)
        //            {
        //                numbers.AppendFormat(" {0}", randForNumbers.Next(-999, 1000));
        //            }
        //            writer.WriteLine(numbers);
        //        }
        //    }
        //    SumSubSeq.Sums.ReadInputAndSolve("test.010.in.txt", 10);
        //}

        public static void GenerateTests(int testNumber)
        {
            string fileName = testNumber > 9 ? String.Format("test.0{0}.in.txt", testNumber) : String.Format("test.00{0}.in.txt", testNumber);
            StreamWriter writer = new StreamWriter(fileName, true);
            Random randForN = new Random();
            Random randForK = new Random();
            Random randForNumbers = new Random();
            Random randForTestInSingleTest = new Random();
            using (writer)
            {
                int currentTestsInSingleTestCount = randForTestInSingleTest.Next(1, MaxTestsInSingleTestCount + 1);
                writer.WriteLine(currentTestsInSingleTestCount);
                StringBuilder numbers = new StringBuilder();

                for (int i = 0; i < currentTestsInSingleTestCount; i++)
                {
                    numbers = new StringBuilder();
                    int randN = randForN.Next(1, 1000);
                    int randK;
                    if (randN <= 5)
                    {
                        randK = randForK.Next(randN);
                    }
                    else
                    {
                        randK = randForK.Next(6);
                    }

                    writer.WriteLine("{0} {1}", randN, randK);

                    numbers.Append(randForNumbers.Next(-999, 1000));
                    for (int j = 0; j < randN - 1; j++)
                    {
                        numbers.AppendFormat(" {0}", randForNumbers.Next(-999, 1000));
                    }
                    writer.WriteLine(numbers);
                }
            }
            SumSubSeq.Sums.ReadInputAndSolve(fileName, testNumber);
        }

        static void Main(string[] args)
        {
            int allTestsCount = 20;
            for (int i = 1; i <= allTestsCount; i++)
            {
                GenerateTests(i);
            }
        }
    }
}
