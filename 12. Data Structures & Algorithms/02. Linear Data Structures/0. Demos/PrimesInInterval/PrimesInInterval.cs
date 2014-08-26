using System;
using System.Collections.Generic;

class PrimesInInterval
{
    static List<int> GetPrimes(int start, int end)
    {
        List<int> primesList = new List<int>();

        for (int num = start; num <= end; num++)
        {	
            bool prime = true;
            for (int div = 2; div <= Math.Sqrt(num); div++)
            {
                if (num % div == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime)
            {
                primesList.Add(num);
            }
        }
        return primesList;
    }

    static void Main()
    {
        List<int> primes = GetPrimes(200, 300);
        foreach (int p in primes)
        {
            Console.Write("{0} ", p);
        }
        Console.WriteLine();
    }
}
