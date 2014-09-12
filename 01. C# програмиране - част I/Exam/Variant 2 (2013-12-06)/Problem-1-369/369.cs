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
            case 3: result = firstNumber + secondNumber; break;
            case 6: result = firstNumber * secondNumber; break;
            case 9: result = firstNumber % secondNumber; break;
        }

        if (result % 3 == 0)
        {
            Console.WriteLine(result / 3);
        }
        else
	    {
            Console.WriteLine(result % 3);
	    }

        Console.WriteLine(result);
    }
}
