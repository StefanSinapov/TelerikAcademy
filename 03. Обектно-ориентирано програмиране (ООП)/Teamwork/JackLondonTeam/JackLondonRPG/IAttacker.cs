using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public interface IAttacker : IIdentifiable
	{
	
		IEnumerable<GameEvent> Attack(IAttackable target);

		int GetDamage();
	}
}
