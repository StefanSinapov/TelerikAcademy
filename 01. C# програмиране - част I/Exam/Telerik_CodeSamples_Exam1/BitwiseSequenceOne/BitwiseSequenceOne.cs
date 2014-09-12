using System;

class BitwiseSequenceOne
{
    static int PrintBitoneNumber(ushort numberOfOnes) // Max. 32
    {
        int binNumber = 0;

        for (int ct = 0; ct < numberOfOnes; ct++)
        {
            binNumber = binNumber * 2 + 1;
        }

        return binNumber;
    }

    static void Main()
    {
        Console.Write("PrintBitoneNumber(ushort x) => x?: ");
        ushort numberOfOnes = UInt16.Parse(Console.ReadLine());

        Console.WriteLine(@"
        Number Of Ones:         {0} 
        Decimal Number:         {1} (return)
        Binary Number:          {2}
        Inverted binary (mask): {3}
        ", numberOfOnes, PrintBitoneNumber(numberOfOnes), Convert.ToString(PrintBitoneNumber(numberOfOnes), 2), Convert.ToString(~ PrintBitoneNumber(numberOfOnes), 2));
    }
}