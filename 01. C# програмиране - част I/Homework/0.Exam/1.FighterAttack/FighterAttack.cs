using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.FighterAttack
{
	class FighterAttack
	{
		static void Main()
		{
			int pX1 = int.Parse(Console.ReadLine());
			int pY1 = int.Parse(Console.ReadLine());
			int pX2 = int.Parse(Console.ReadLine());
			int pY2 = int.Parse(Console.ReadLine());
			int fX = int.Parse(Console.ReadLine());
			int fY = int.Parse(Console.ReadLine());
			int d = int.Parse(Console.ReadLine());

			int totalDamage = 0;


			//exchange
			if(pX1>pX2)
			{
				pX1 = pX1 + pX2;
				pX2 = pX1 - pX2;
				pX1 = pX1 - pX2;
			}

			if(pY1<pY2 )
			{
				pY1 = pY1 + pY2;
				pY2 = pY1 - pY2;
				pY1 = pY1 - pY2;
			}

			//100%
			if ((fX+d)>=pX1 && (fX+d)<=pX2 && fY<=pY1 && fY>=pY2)
			{
				totalDamage = totalDamage + 100;
			}

			//75%
			if ((fX + d+1) >= pX1 && (fX + d+1) <= pX2 && fY <= pY1 && fY >= pY2)
			{
				totalDamage = totalDamage + 75;
			}

			//50% up
			if ((fX + d) >= pX1 && (fX + d) <= pX2 && (fY+1) <= pY1 && (fY+1) >= pY2)
			{
				totalDamage = totalDamage + 50;
			}

			//50% down
			if ((fX + d) >= pX1 && (fX + d) <= pX2 && (fY - 1) <= pY1 && (fY - 1) >= pY2)
			{
				totalDamage = totalDamage + 50;
			}
			Console.WriteLine(totalDamage+"%");

		}
	}
}
