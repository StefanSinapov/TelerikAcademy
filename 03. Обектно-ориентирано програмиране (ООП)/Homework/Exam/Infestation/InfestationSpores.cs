using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class InfestationSpores : Supplement
	{
		private const int DefaultPower = -1;
		private const int DefaultAggression = 20;

		public InfestationSpores()
			:base()
		{
			this.PowerEffect = InfestationSpores.DefaultPower;
			this.AggressionEffect = InfestationSpores.DefaultAggression;
		}

		public override void ReactTo(ISupplement otherSupplement)
		{
			if(otherSupplement is InfestationSpores)
			{
				this.AggressionEffect = InfestationSpores.DefaultAggression;
			}
			base.ReactTo(otherSupplement);
		}
	}
}
