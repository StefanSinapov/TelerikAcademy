using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
	public class Giant : Character, IFighter, IGatherer
	{
		private const int DefaultGiantAttackPoints = 150;
		private const int DefaultGiantDefencePoints = 80;
		private const int DefaultGiantHitPoints = 200;
		private const int DefaultOwner = 0;
		private const int IncreasingAttackingPoints = 100;

		public Giant(string name, Point position)
			: base(name, position, DefaultOwner)
		{
			this.AttackPoints = DefaultGiantAttackPoints;
			this.DefensePoints = DefaultGiantDefencePoints;
			this.HitPoints = DefaultGiantHitPoints;
		}

		public int AttackPoints { get; set; }

		public int DefensePoints { get; set; }

		public int GetTargetIndex(List<WorldObject> availableTargets)
		{
			for (int i = 0; i < availableTargets.Count; i++)
			{
				if (availableTargets[i].Owner != 0)
				{
					return i;
				}
			}

			return -1;
		}

		public bool TryGather(IResource resource)
		{
			if (resource.Type == ResourceType.Stone)
			{
				this.AttackPoints += IncreasingAttackingPoints;
				return true;
			}

			return false;
		}
	}
}
