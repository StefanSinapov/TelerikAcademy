using System;

class FactorialMethod
{
    static long Factorial(short number)
    {
        long pass = number;

        for (int ct = number - 1; ct > 1; ct--)
        {
            pass *= ct;
        }

        return pass;
    }

    static void Main()
    {
        Console.WriteLine(Factorial(5));
    }
}