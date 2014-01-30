using System;

class OnKeyPress // Real-time key state detector
{
    static void KeyState()
    {
        for (;;)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                default:
                    Console.WriteLine("LEFT");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("RIGHT");
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("ESCAPE");
                    break;
                case ConsoleKey.A:
                    Console.WriteLine("A");
                    break;
            }
        }
    }

    static void KeyPress()
    {
        for (; ; )
        {
            if (Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                Console.WriteLine("Do something (ENTER PRESSED)");
            }
        }
    }

    static void Main()
    {
        //KeyState();
        KeyPress();
        // For loop should be removed if the key detection have to be executed once (not-game app).
    }
}