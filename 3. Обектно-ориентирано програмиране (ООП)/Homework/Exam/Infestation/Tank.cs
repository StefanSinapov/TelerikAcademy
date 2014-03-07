using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class Tank : Unit
	{
		private const int DefaultTankPower = 25;
		private const int DefaultTankHealth = 20;
		private const int DefaultTankAggression = 25;

		public Tank(string id)
			: base(id, UnitClassification.Mechanical, DefaultTankHealth, DefaultTankPower, DefaultTankAggression)
		{

		}

	}
}
