using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
	public class Knight : Character, IFighter
	{
		private const int KnightAttackPoints = 100;
		private const int KnightDefencePoints = 100;
		private const int KnightHitPoints = 100;

		public Knight(string initialName, Point initialPosition, int owner)
			: base(initialName, initialPosition, owner)
		{
			this.AttackPoints = KnightAttackPoints;
			this.DefensePoints = KnightDefencePoints;
			this.HitPoints = KnightHitPoints;
		}

		public int AttackPoints { get; set; }

		public int DefensePoints { get; set; }

		public int GetTargetIndex(List<WorldObject> availableTargets)
		{
			for (int i = 0; i < availableTargets.Count; i++)
			{
				if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
