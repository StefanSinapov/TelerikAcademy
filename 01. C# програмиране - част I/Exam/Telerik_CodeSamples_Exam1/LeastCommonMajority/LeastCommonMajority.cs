using System;

class LeastCommonMajority
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

    static int Lcm(int a, int b)
    {
        if (a == 0 && b == 0)
        {
            return 0;
        }
        else
        {
            return Math.Abs(a * b) / Gcd(a, b);
        }
    }

    static void Main()
    {
        Console.WriteLine(Lcm(15, 3));
    }
}