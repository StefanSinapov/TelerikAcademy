namespace _05.Businessmen
{
    using System;
    using System.Numerics;

    class Businessmen
    {
        static void Main()
        {
           /* var N = int.Parse(Console.ReadLine());

            var numbers = new[]
            {
               1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 
               2674440, 9694845, 35357670, 129644790, 477638700, 1767263190, 6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452, 18367353072152, 
               69533550916004, 263747951750360, 1002242216651368, 3814986502092304, 14544636039226909, 55534064877048198,
               212336130412243110, 812944042149730764, 3116285494907301262
            };

            Console.WriteLine(numbers[N/2]);*/

            int n;
            do
            {
                n = int.Parse(Console.ReadLine());
            } while (n < 0);

            //remove this to get all numbers
            n = n/2;
            // <<<<>>>>

            BigInteger fact2N = 1;
            BigInteger factNPlus1 = 1;
            BigInteger factN = 1;
            for (int i = 1; i <= n; i++)
            {
                factN *= i;
            }
            for (int k = 1; k <= 2 * n; k++)
            {
                fact2N *= k;
            }
            for (int j = 1; j <= n + 1; j++)
            {
                factNPlus1 *= j;
            }
            Console.WriteLine(fact2N / (factNPlus1 * factN));
        }

    }
}
