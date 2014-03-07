using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
	public class Zombie : Animal
	{
		private const int DefaultZombieSize = 0;
		private const int DefaultZombieQuantity = 10;

		public Zombie(string name, Point position)
			: base(name, position, DefaultZombieSize)
		{

		}

		public override int GetMeatFromKillQuantity()
		{
			return DefaultZombieQuantity;
		}
	}
}
