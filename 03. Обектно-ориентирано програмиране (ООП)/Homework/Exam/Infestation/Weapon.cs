using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class Weapon : Supplement
	{
		private const int DefaultWeaponPower = 10;
		private const int DefaultWeaponAggression = 3;
		public Weapon()
			:base()
		{
			
		}

		public override void ReactTo(ISupplement otherSupplement)
		{
			if(otherSupplement is WeaponrySkill)
			{
				this.PowerEffect = Weapon.DefaultWeaponPower;
				this.AggressionEffect = Weapon.DefaultWeaponAggression;
			}
			base.ReactTo(otherSupplement);
		}
	}
}
