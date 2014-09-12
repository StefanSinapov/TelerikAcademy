using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JackLondonRPG
{
	public class AttackEvent : GameEvent
	{
		private IAttacker attacker;
		private IAttackable target;
		private bool shotConnected;

		public AttackEvent(IAttacker attacker, IAttackable target, bool shotConnected)
		{
			this.Attacker = attacker;
			this.Target = target;
			this.ShotConnected = shotConnected;
		}

		public bool ShotConnected
		{
			get
			{
				return this.shotConnected;
			}
			private set
			{
				this.shotConnected = value;
			}
		}

		public IAttacker Attacker
		{
			get
			{
				return this.attacker;
			}
			private set
			{
				this.attacker = value;
			}
		}

		public IAttackable Target
		{
			get
			{
				return this.target;
			}
			private set
			{
				this.target = value;
			}
		}

		public override string GetMessage()
		{
			string returnValue = "";
			returnValue += this.Attacker.Name + " attacked " + this.Target.Name + "\n";

			return returnValue;
		}
	}
}
