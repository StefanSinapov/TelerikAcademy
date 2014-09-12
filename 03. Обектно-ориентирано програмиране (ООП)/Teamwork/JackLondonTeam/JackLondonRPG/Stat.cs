using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public class Stat<T> : IUpgradable<T>, ICloneable
	{
		private List<T> rankValues;

		public Stat(string name, List<T> rankValues)
		{
			this.Name = name;
			this.CurrRank = 0;
			this.MaxRank = rankValues.Count;
			this.rankValues = new List<T>(rankValues);
		}

		public string Name { get; private set; }

		public int CurrRank { get; private set; }
		public int MaxRank { get; private set; }

		public T CurrValue
		{
			get
			{
				return this.rankValues[this.CurrRank];
			}
		}

		public IEnumerable<GameEvent> RankChange(int rankManipulator)//rankManipulator shows by how many ranks the stat should go up or down in case of negative numbers.
		{
			int newRank = this.CurrRank + rankManipulator;

			if (newRank < 0)
			{
				newRank = 0;
			}
			if (newRank >= this.MaxRank)
			{
				newRank = this.MaxRank - 1;
			}

			this.CurrRank = newRank;

			List<GameEvent> events = new List<GameEvent>();
			events.Add(new UpgradeEvent<T>(this));

			return events;
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
