using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class Parasite : InfestUnit
	{
		public const int DefaultParasitePower = 1;
		public const int DefaultParasiteAggression = 1;
		public const int DefaultParasiteHealth = 1;

		public Parasite(string id)
			: base(id, UnitClassification.Biological, Parasite.DefaultParasiteHealth, Parasite.DefaultParasitePower, Parasite.DefaultParasiteAggression)
		{

		}

		public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
		{
			var orderedUnits = units.OrderBy((u) => u.Health);
			foreach (var unit in orderedUnits)
			{
				if (this.Id != unit.Id && unit.UnitClassification == UnitClassification.Biological)
				{

					return new Interaction(new UnitInfo(this), unit, InteractionType.Infest);
				}


			}
			return base.DecideInteraction(units);
		}
	}
}
