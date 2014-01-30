using System;

class Program
{
    static int Fibonacci(int element)
    {
        if (element == 0)
            return 0;
        else if (element == 1)
            return 1;
        else
            return Fibonacci(element - 1) + Fibonacci(element - 2);
    }

    static void Main()
    {
        for (int ct = 0; ct < 6; ct++)
        {
            Console.WriteLine(Fibonacci(ct));
        }
    }
}