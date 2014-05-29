namespace Methods
{
    using System;

    public class MethodsDemo
    {
        public static void Main()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            double triangleArea = Utility.CalcTriangleArea(sideA, sideB, sideC);
            Console.WriteLine("Area of triangle with sides a={0}, b={1}, c={2} is: {3}", sideA, sideB, sideC, triangleArea);

            int digit = 5;
            string digitAsWord = Utility.DigitToWord(digit);
            Console.WriteLine("Digit {0} is spelled as {1}", digit, digitAsWord);

            int[] array = { 5, -1, 3, 2, 14, 2, 3 };
            int maxElementIntArray = Utility.FindMax(array);
            Console.WriteLine("Maximum element in array is: {0}", maxElementIntArray);

            Console.WriteLine("<-----Print Numbers----->");
            double a = 1.3;
            double b = 2;
            double c = 2.30;
            Utility.PrintWithFixedPoint(a);
            Utility.PrintAsPercent(b);
            Utility.PrintWithRightAlignment(c);

            Console.WriteLine("<----Points----->");
            Point firstPoint = new Point(3, -1);
            Point secondPoint = new Point(3, 2.5);
            bool areHorizontal = Point.AreHorizontal(firstPoint, secondPoint);
            bool areVertical = Point.AreVerticle(firstPoint, secondPoint);
            double distanceBetweenPoints = Point.CalculateDistance(firstPoint, secondPoint);
            Console.WriteLine("Distance between {0} and {1} is: {2}", firstPoint, secondPoint, distanceBetweenPoints);
            Console.WriteLine("Points {0} and {1} are vertical: {2}", firstPoint, secondPoint, areVertical);
            Console.WriteLine("Points {0} and {1} are horizontal: {2}", firstPoint, secondPoint, areHorizontal);

            Console.WriteLine("<-----Students------>");
            Student pesho = new Student("Pesho", "Peshev", DateTime.Parse("17.03.1992"));
            Student gosho = new Student("Gosho", "Goshev", DateTime.Parse("03.11.1993"));
            Console.WriteLine("{0} older than {1} -> {2}", pesho.FirstName, pesho.LastName, pesho.IsOlderThan(gosho));
        }
    }
}
