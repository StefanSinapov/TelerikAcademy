using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public abstract class InfestUnit : Unit
	{
		public InfestUnit(string id, UnitClassification unitType, int health, int power, int aggression)
			: base(id, unitType, health, power, aggression)
		{

		}

		public virtual void Infest(Unit unit)
		{
			unit.AddSupplement(new InfestationSpores());
		}

		
	}
}
