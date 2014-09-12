using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class Queen : InfestUnit
	{
		public const int DefaultQueenPower = 1;
		public const int DefaultQueenAggression = 1;
		public const int DefaultQueenHealth = 30;

		public Queen(string id)
			: base(id, UnitClassification.Psionic, Queen.DefaultQueenHealth, Queen.DefaultQueenPower, Queen.DefaultQueenAggression)
		{

		}

		public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
		{
			var orderedUnits = units.OrderBy((u) => u.Health);
			foreach (var unit in orderedUnits)
			{
				if (this.Id != unit.Id && unit.UnitClassification == UnitClassification.Mechanical || unit.UnitClassification == UnitClassification.Psionic)
				{

					return new Interaction(new UnitInfo(this), unit, InteractionType.Infest);
				}


			}
			return base.DecideInteraction(units);
		}
	}
}
