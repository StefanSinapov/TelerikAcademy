using System;

class ThreeSixNine
{
    static void Main()
    {
        long firstNumber = long.Parse(Console.ReadLine());
        int code = int.Parse(Console.ReadLine());
        long secondNumber = long.Parse(Console.ReadLine());

        long result = 0;

        switch (code)
        {
            case 2: result = firstNumber % secondNumber; break;
            case 4: result = firstNumber + secondNumber; break;
            case 8: result = firstNumber * secondNumber; break;
        }

        if (result % 4 == 0)
        {
            Console.WriteLine(result / 4);
        }
        else
	    {
            Console.WriteLine(result % 4);
	    }

        Console.WriteLine(result);
    }
}
