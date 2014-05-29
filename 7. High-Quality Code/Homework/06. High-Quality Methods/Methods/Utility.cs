namespace Methods
{
    using System;

    public static class Utility
    {
        public static string DigitToWord(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException("Number must be in range [0 - 9]");
            }

            string result = string.Empty;
            switch (digit)
            {
                case 0:
                    result = "zero";
                    break;
                case 1:
                    result = "one";
                    break;
                case 2:
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8:
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
            }

            return result;
        }

        public static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }
            else if (!CanMakeTriangle(sideA, sideB, sideC))
            {
                throw new ArgumentException("This sides don't make up a triangle");
            }

            double s = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
            return area;
        }

        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Array cannot be null");
            }
            else if (elements.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty");
            }

            int max = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        public static void PrintAsPercent(double number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintWithFixedPoint(double number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintWithRightAlignment(double number)
        {
            Console.WriteLine("{0,8}", number);
        }

        private static bool CanMakeTriangle(double sideA, double sideB, double sideC)
        {
            return (sideA + sideB > sideC) && (sideB + sideC > sideA) && (sideA + sideC > sideB);
        }
    }
}
