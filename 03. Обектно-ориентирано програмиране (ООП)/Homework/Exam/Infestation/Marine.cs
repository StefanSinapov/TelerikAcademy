using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class Marine : Human
	{
		private readonly WeaponrySkill DefaultMarineSupplement = new WeaponrySkill();
        public Marine(string id)
			: base(id)
        {
			this.AddSupplement(this.DefaultMarineSupplement);
        }

		protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
		{
			//return attackableUnits.OrderBy((u) => u.Health).Select((u) => u.Power <= this.Power);

			var sortedUnits = attackableUnits.OrderByDescending((u) => u.Health);

			foreach (var unit in sortedUnits)
			{
				if (unit.Power <= this.Power)
				{
					return unit;
				}
			}

			return base.GetOptimalAttackableUnit(attackableUnits);
		}

		protected override bool CanAttackUnit(UnitInfo unit)
		{
			return base.CanAttackUnit(unit);
		}
		

	}
}
