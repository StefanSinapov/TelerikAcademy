/*
 * * Implement the "Falling Rocks" game in the text console. 
 * A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). 
 * A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.
 * Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
 * The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
 * Implement collision detection and scoring system.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FallingRocks
{
	class Program
	{
		class Rocks
		{
			public int x;
			public int y;

			public Rocks(int x,int y)
			{
				this.x=x;
				this.y=y;
			}

		}
		static void Main(string[] args)
		{
		}
	}
}
