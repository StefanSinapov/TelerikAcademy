using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class AggressionCatalyst : Catalist
	{
		private const int DefautAggressionEffect = 3;

		public AggressionCatalyst()
			:base()
		{
			this.AggressionEffect = AggressionCatalyst.DefautAggressionEffect;
		}
	}
}
