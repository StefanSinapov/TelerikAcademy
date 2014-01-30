using System;

class GreatestCommonDivisor
{
    static int Gcd(int a, int b)
    {
        int t;

        while (b != 0)
        {
            t = a % b;
            a = b;
            b = t;
        }

        return a;
    }

    static void Main()
    {
        Console.WriteLine(Gcd(15, 5));
    }
}