using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression.TestGenerator
{
    class ExpressionGenerator
    {
        static readonly Random rand = new Random();
        const string OperandValues = "123456789";

        const string TestsDirectory = "..//..//tests";
        const string InputFileFormat = "{0}/test.{1:000}.in.txt";
        const string OutputFileFormat = "{0}/test.{1:000}.out.txt";

        const int EasyTestMinOperandsCount = 5;
        const int EasyTestMaxOperandsCount = 10;
        const int EasyTestMinSectionsCount = 0;
        const int EasyTestMaxSectionsCount = 3;

        const int MediumTestMinOperandsCount = 10;
        const int MediumTestMaxOperandsCount = 50;
        const int MediumTestMinSectionsCount = 3;
        const int MediumTestMaxSectionsCount = 8;

        const int HardTestMinOperandsCount = 100;
        const int HardTestMaxOperandsCount = 500;
        const int HardTestMinSectionsCount = 20;
        const int HardTestMaxSectionsCount = 50;

        const int MaxOperandsCount = 1000;
        const int MaxSectionsCount = 100;

        static void Main()
        {
            if (!Directory.Exists(TestsDirectory))
            {
                Directory.CreateDirectory(TestsDirectory);
            }

            Console.WriteLine("How many tests to be generated?");
            int testsCount = int.Parse(Console.ReadLine());

            int easyTestsCount = 3 * testsCount / 10;
            int mediumTestsCount = 3 * testsCount / 10;
            int hardTestsCount = 3 * testsCount / 10;
            int maxTestsCount = testsCount - easyTestsCount - mediumTestsCount - hardTestsCount;

            for (var i = 0; i < easyTestsCount; i++)
            {
                GenerateEasyTest(i + 1);
            }

            for (var i = easyTestsCount; i < easyTestsCount + mediumTestsCount; i++)
            {
                GenerateMediumTest(i + 1);
            }

            for (var i = easyTestsCount + mediumTestsCount; i < easyTestsCount + mediumTestsCount + hardTestsCount; i++)
            {
                GenerateHardTest(i + 1);
            }

            for (var i = easyTestsCount + mediumTestsCount + hardTestsCount; i < easyTestsCount + mediumTestsCount + hardTestsCount + maxTestsCount; i++)
            {
                GenerateMaxTest(i + 1);
            }
        }

        private static void GenerateEasyTest(int testIndex)
        {
            var operandsCount = rand.Next(EasyTestMinOperandsCount, EasyTestMaxOperandsCount);
            var sectionsCount = rand.Next(EasyTestMinSectionsCount, EasyTestMaxSectionsCount);

            GenerateTest(testIndex, operandsCount, sectionsCount);
        }

        private static void GenerateMediumTest(int testIndex)
        {
            var operandsCount = rand.Next(MediumTestMinOperandsCount, MediumTestMaxOperandsCount);
            var sectionsCount = rand.Next(MediumTestMinSectionsCount, MediumTestMaxSectionsCount);

            GenerateTest(testIndex, operandsCount, sectionsCount);
        }

        private static void GenerateHardTest(int testIndex)
        {
            var operandsCount = rand.Next(HardTestMinOperandsCount, HardTestMaxOperandsCount);
            var sectionsCount = rand.Next(HardTestMinSectionsCount, HardTestMaxSectionsCount);

            GenerateTest(testIndex, operandsCount, sectionsCount);
        }

        private static void GenerateMaxTest(int testIndex)
        {
            GenerateTest(testIndex, MaxOperandsCount, MaxSectionsCount);
        }

        private static void GenerateTest(int testIndex, int operandsCount, int sectionsCount)
        {
            var expression = GenerateExpression(operandsCount, sectionsCount);
            ValidateExpression(expression, testIndex);

            var inputFilePath = string.Format(InputFileFormat, TestsDirectory, testIndex);
            using (StreamWriter writer = new StreamWriter(inputFilePath))
            {
                writer.WriteLine(expression);
            }

            Console.SetIn(new StreamReader(inputFilePath));
            var result = SolveExpression();
            var outputFilePath = string.Format(OutputFileFormat, TestsDirectory, testIndex);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("{0:0.00}", result);
            }
        }

        private static void ValidateExpression(string expression, int testIndex = -1)
        {
            int bracketsCount = 0;
            for (var i = 0; i < expression.Length; i++)
            {
                var token = expression[i];
                if (token == '(')
                {
                    bracketsCount++;
                }
                else if (token == ')')
                {
                    bracketsCount--;
                }
                if (bracketsCount != 1 && bracketsCount != 0)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Invalid bracket at {0} in test {1}", i, testIndex));
                }
            }
        }

        static decimal SolveExpression()
        {
            int symbol = Console.Read();
            decimal sum = 0;
            int o = '+';

            while (symbol != '=')
            {
                if (symbol == '(')
                {
                    decimal innerSum = 0;
                    int innerO = '+';
                    symbol = Console.Read();

                    while (symbol != ')')
                    {
                        if (0 <= symbol - '0' && symbol - '0' <= 9)
                        {
                            switch (innerO)
                            {
                                case '+':
                                    innerSum += symbol - '0';
                                    break;
                                case '-':
                                    innerSum -= symbol - '0';
                                    break;
                                case '*':
                                    innerSum *= symbol - '0';
                                    break;
                                case '/':
                                    innerSum /= symbol - '0';
                                    break;
                                case '%':
                                    innerSum %= symbol - '0';
                                    break;
                            }
                        }
                        else if (symbol == '+' ||
                                 symbol == '-' ||
                                 symbol == '/' ||
                                 symbol == '*')
                        {
                            innerO = symbol;
                        }
                        symbol = Console.Read();
                    }

                    switch (o)
                    {
                        case '+':
                            sum += innerSum;
                            break;
                        case '-':
                            sum -= innerSum;
                            break;
                        case '*':
                            sum *= innerSum;
                            break;
                        case '/':
                            sum /= innerSum;
                            break;
                        case '%':
                            sum %= innerSum;
                            break;
                    }
                }
                else if (0 <= symbol - '0' && symbol - '0' <= 9)
                {
                    switch (o)
                    {
                        case '+':
                            sum += symbol - '0';
                            break;
                        case '-':
                            sum -= symbol - '0';
                            break;
                        case '*':
                            sum *= symbol - '0';
                            break;
                        case '/':
                            sum /= symbol - '0';
                            break;
                        case '%':
                            sum %= symbol - '0';
                            break;
                    }
                }
                else if (symbol == '+' ||
                         symbol == '-' ||
                         symbol == '/' ||
                         symbol == '*' ||
                         symbol == '%')
                {
                    o = symbol;
                }
                symbol = Console.Read();
            }
            return sum;
        }

        static string GenerateExpression(int operandsCount, int sectionsCount)
        {
            StringBuilder expressionBuilder = new StringBuilder();

            for (var i = 0; i < operandsCount; i++)
            {
                var operandIndex = rand.Next(OperandValues.Length);
                expressionBuilder.Append(OperandValues[operandIndex]);
                if (i != operandsCount - 1)
                {
                    var operatorDecider = rand.Next(100);
                    if (operatorDecider % 30 == 0)
                    {
                        expressionBuilder.Append("*");
                    }
                    else if (operatorDecider % 32 == 0 || operatorDecider % 31 == 0 || operatorDecider % 33 == 0)
                    {
                        expressionBuilder.Append("/");
                    }
                    else if (operatorDecider % 2 == 0)
                    {
                        expressionBuilder.Append("+");
                    }
                    else if (operatorDecider % 2 == 1)
                    {
                        expressionBuilder.Append("-");
                    }
                }
            }

            var sectionLength = (expressionBuilder.Length + sectionsCount) / ((sectionsCount == 0) ? 1 : sectionsCount);
            int minSectionStart = 0;
            int maxSectionEnd = sectionLength;

            for (var i = 0; i < sectionsCount; i++)
            {
                var sectionStart = rand.Next(minSectionStart, (minSectionStart + maxSectionEnd) / 2);
                if (OperandValues.Any(o => o == expressionBuilder[sectionStart]))
                {
                    expressionBuilder.Insert(sectionStart, "(");
                }
                else
                {
                    expressionBuilder.Insert(sectionStart + 1, "(");
                }
                var sectionEnd = rand.Next(sectionStart + sectionLength / 2, maxSectionEnd);
                if (OperandValues.Any(o => o == expressionBuilder[sectionEnd]))
                {
                    expressionBuilder.Insert(sectionEnd + 1, ")");
                }
                else
                {
                    expressionBuilder.Insert(sectionEnd, ")");
                }

                minSectionStart = sectionEnd + 2;
                maxSectionEnd += sectionLength;
            }
            expressionBuilder.Append("=");

            expressionBuilder.Replace("/0", "/1");

            return expressionBuilder.ToString();
        }
    }
}