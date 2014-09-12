using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorShip
{
    public class Rock
    {
        private Random random = new Random();
        private char[,] matrix;
        private int x;
        private int y;
        private int width;
        private int height;
        private char rockPosition;
        public char rockSymbol = 'O';
        private ConsoleColor colour;

        public Rock(char rockType)
        {           
            this.rockPosition = rockType;
            colour = GetRandomConsoleColor();
            height = random.Next(1, 3);
            width = random.Next(1, 3);
            this.matrix = new char[this.height, this.width];
        }

        //Added by Dobrin for creating bombs with no random color, height and width
        public Rock(char rockType, int height, int width, ConsoleColor color)
        {
            this.rockPosition = rockType;
            this.colour = color;
            this.height = height;
            this.width = width;
            this.matrix = new char[this.height, this.width];
        }


        public char Position
        {
            get { return this.rockPosition; }
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public int Height
        {
            get { return this.height; }
        }

        public int Width
        {
            get { return this.width; }
        }

        //added by Dobrin
        public char RockSymbol
        {
            get { return this.rockSymbol; }
            set { this.rockSymbol = value; }
        }


        private ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            
            return (ConsoleColor)consoleColors.GetValue(random.Next(consoleColors.Length));
        }

        private int GetRandomX()
        {
            return random.Next(0, Console.WindowHeight - this.Height - Field.StatusBar);
        }

        private int GetRandomY()
        {
            return random.Next(0, Console.WindowWidth - this.Width);
        }

        private void GetColour()
        {
            if (this.colour != ConsoleColor.Black)
            {
                Console.ForegroundColor = this.colour;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public void ReinitiateRock()
        {
            switch (this.Position)
            {
                case 'u': this.X = 0; this.Y = GetRandomY(); break;
                case 'l': this.Y = 0; this.X = GetRandomX(); break;
                case 'r': this.Y = Console.WindowWidth - this.Width; this.X = GetRandomX(); break;
                case 'd': this.X = Console.WindowHeight - this.Height - Field.StatusBar; this.Y = GetRandomY(); break;
            }
        }

        public void DrowRock()
        {
            GetColour();
            for (int i = 0; i < this.width; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    Console.SetCursorPosition(i + this.y, j + this.x);
                    Console.Write(rockSymbol);
                }
            }
            Console.ResetColor();
        }

    }
}
