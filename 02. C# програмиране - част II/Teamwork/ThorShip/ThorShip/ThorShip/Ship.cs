using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThorShip
{
    public class Ship
    {
        //Fields
		//public List<Field.Coordinates> ShipCoords=new List<Field.Coordinates>();
        private int xCoordinate;
        private int yCoordinate;
        private int size;
        private int[,] shipMatrix;

        //Properties
        public int[,] ShipMatrix
        {
            get { return this.shipMatrix; }
            set { this.shipMatrix = value; }
        }

        public int XCoordinate
        {
            get { return this.xCoordinate; }
            set { this.xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return this.yCoordinate; }
            set { this.yCoordinate = value; }
        }
        public int Size
        {
            get { return this.ShipMatrix.GetLength(0); }
            set { this.size = value; }
        }

        //Constructors
        public Ship(int size)
        {
            this.ShipMatrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row == size / 2 || col == size - 2)
                    {
                        this.shipMatrix[row, col] = 1;
                    }
                    if (col == size - 1 || col == size / 2)
                    {
                        this.shipMatrix[(size / 2) - 1, col] = 1;
                        this.shipMatrix[(size / 2) + 1, col] = 1;
                    }
                    else if (col > size / 2 && row != 0 && row != size - 1)
                    {
                        this.shipMatrix[row, col] = 1;
                    }
                }
            }
        }

        //Methods

        public void DrawShip(int x, int y, char c = '#', ConsoleColor color = ConsoleColor.Blue)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;

            for (int row = 0; row < this.shipMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.shipMatrix.GetLength(1); col++)
                {
                    if (this.shipMatrix[row, col] != 0)
                    {
                        Console.SetCursorPosition(row + x, col + y);
                        Console.Write(c);
                    }
                }
            }
			Console.ForegroundColor = ConsoleColor.Gray;
			
        }

        public void MoveShip()
        {
          
            int speed = 2;
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                while (Console.KeyAvailable) Console.ReadKey(true);

                //Increase and decrease speed
                if (pressedKey.Key == ConsoleKey.D1 && speed < 10)
                {
                    speed++;

                }
               
                if (pressedKey.Key == ConsoleKey.D2 && speed > 1)
                {

                    speed--;

                }

                //Shooting
                if (pressedKey.Key == ConsoleKey.A)
                {
                    Shooting.Shoot('l');
                }

                if (pressedKey.Key == ConsoleKey.D)
                {
                    Shooting.Shoot('r');
                }

                if (pressedKey.Key == ConsoleKey.W)
                {
                    Shooting.Shoot('u');
                }
                if (pressedKey.Key == ConsoleKey.S)
                {
                    Shooting.Shoot('d');
                }

                //Navigation
                if (pressedKey.Key == ConsoleKey.LeftArrow)
                {
                    if (this.XCoordinate - speed > 0)
                    {
                        this.XCoordinate -= speed;
                    }
                    else if (this.XCoordinate - speed <= 0)
                    {
                        this.XCoordinate = 0;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (this.XCoordinate + speed < Console.BufferWidth - this.Size + 1 )
                    {
                        this.XCoordinate += speed;
                    }
                    else if (this.XCoordinate + speed >= Console.BufferWidth - this.Size + 1)
                    {
                        this.XCoordinate = Console.BufferWidth - this.Size;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    if (this.YCoordinate - speed > 0)
                    {
                        this.YCoordinate -= speed;
                    }
                    else if (this.YCoordinate - speed <= 0)
                    {
                        this.YCoordinate = 0;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    if (this.YCoordinate + speed < Console.BufferHeight - Field.StatusBar - this.Size)
                    {
                        this.YCoordinate += speed;
                    }
                    else if (this.YCoordinate + speed >= Console.BufferHeight - Field.StatusBar - this.Size)
                    {
                        this.YCoordinate = Console.BufferHeight - Field.StatusBar - this.Size;
                    }
                }
            }
        }
    }
}
