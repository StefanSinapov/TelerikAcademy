using System;

class OptimizedPower
{
    static double Power(int number, int power)
    {
        double pass = number;
        for (int ct = 1; ct < power; ct++)
        {
            pass *= number;
        }

        return pass;
    }

    static void Main()
    {
        Console.WriteLine(Power(2, 16));
    }
}