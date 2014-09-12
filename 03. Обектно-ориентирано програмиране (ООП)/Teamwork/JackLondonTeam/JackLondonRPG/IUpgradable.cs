using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public interface IUpgradable<T> : IIdentifiable
	{
		int CurrRank { get; }

		T CurrValue
		{
			get;
		}

		int MaxRank
		{
			get;
		}
	
		IEnumerable<GameEvent> RankChange(int rankManipulator);
	}
}
