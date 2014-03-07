using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
	public class UpgradeEvent<T> : GameEvent
	{
		public UpgradeEvent(IUpgradable<T> upgradedEntity)
		{
			this.UgradedEntity = upgradedEntity;
		}

		public IUpgradable<T> UgradedEntity { get; private set; }

		public override string GetMessage()
		{
			string returnValue = "";

			returnValue += this.UgradedEntity.Name + " gets upgraded to rank " + this.UgradedEntity.CurrRank;

			return returnValue;
		}
	}
}
