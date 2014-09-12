using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
	public class Ninja : Character, IFighter, IGatherer
	{
		private const int DefaultNinjaAttackPoints = 0;
		private const int DefaultNinjaDefencePoints = int.MaxValue;
		private const int DefaultNinjaHitPoints = 1;

		public Ninja(string name, Point position, int owner)
			: base(name, position, owner)
		{
			this.AttackPoints = DefaultNinjaAttackPoints;
			this.DefensePoints = DefaultNinjaDefencePoints;
			this.HitPoints = DefaultNinjaHitPoints;
			
		}

		public int AttackPoints { get; set; }

		public int DefensePoints { get; set; }

		public int GetTargetIndex(List<WorldObject> availableTargets)
		{
			int index = 0;
			int tempHitPoints = int.MinValue;
			bool isTargets = false;
			for (int i = 0; i < availableTargets.Count; i++)
			{
				if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0 && availableTargets[i].HitPoints > tempHitPoints)
				{
					index = i;
					tempHitPoints = availableTargets[i].HitPoints;
					isTargets = true;
				}
			}
			if (isTargets)
			{
				return index;
			}
			else
			{
				return -1;
			}
		}

		public bool TryGather(IResource resource)
		{
			if (resource.Type == ResourceType.Lumber)
			{
				this.AttackPoints += resource.Quantity;
				return true;
			}
			else if (resource.Type == ResourceType.Stone)
			{
				this.AttackPoints += resource.Quantity * 2;
				return true;
			}

			return false;
		}

		
	}
}
