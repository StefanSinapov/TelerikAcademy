using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public class DamageEvent : GameEvent
	{
		public DamageEvent(IDamageable damagedEntity, int damageAmount)
		{
			this.DamagedEntity = damagedEntity;
			this.DamageAmount = damageAmount;
		}

		public int DamageAmount { get; private set; }
		public IDamageable DamagedEntity { get; private set; }

		public override string GetMessage()
		{
			string returnValue = "";

			if (this.DamageAmount < 0)
			{
				returnValue += this.DamagedEntity.Name + " gets healed for " + (-this.DamageAmount);
			}

			if (this.DamageAmount > 0)
			{
				returnValue += this.DamagedEntity.Name + " gets damaged for " + this.DamageAmount;
			}

			return returnValue;
		}
	}
}
