using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class PowerCatalyst : Catalist
	{
		private const int DefaultPowerEffect = 3;

		public PowerCatalyst()
			: base()
		{
			this.PowerEffect = DefaultPowerEffect;
		}
	}
}
