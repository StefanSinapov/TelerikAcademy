using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public abstract class GameEvent : IDrawable
	{
		public abstract string GetMessage();

		public char[,] GetImage()
		{
			string message = this.GetMessage();
			
			char[,] returnValue = new char[1, message.Length];
			
			for (int i = 0; i < message.Length; ++i)
			{
				returnValue[0, i] = message[i];
			}

			return returnValue;
		}
	}
}
