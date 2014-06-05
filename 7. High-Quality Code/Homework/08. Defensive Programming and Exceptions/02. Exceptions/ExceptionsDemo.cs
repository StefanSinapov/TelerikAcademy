namespace StudentExamSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsDemo
    {
        public static void Main()
        {
            var substr = Utilities.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(Utilities.ExtractEnding("I love C#", 2));
            Console.WriteLine(Utilities.ExtractEnding("Nakov", 4));
            Console.WriteLine(Utilities.ExtractEnding("beer", 4));
            Console.WriteLine(Utilities.ExtractEnding("Hi", 100));

            var validPrime = 23;
            var isPrime = Utilities.CheckPrime(validPrime);
            Console.WriteLine(validPrime + " is prime: " + isPrime);

            var invalidNumber = -23;
            try
            {
                Utilities.CheckPrime(invalidNumber);
                Console.WriteLine(invalidNumber + " is prime.");
            }
            catch (Exception)
            {
                Console.WriteLine(invalidNumber + " is not prime. ");
            }

            // Student
            IList<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            Student peter = new Student("Peter", "Petrov", peterExams);
            double peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}