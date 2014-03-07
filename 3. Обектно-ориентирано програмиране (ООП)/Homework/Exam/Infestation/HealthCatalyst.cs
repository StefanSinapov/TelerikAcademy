using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
	public class HealthCatalyst : Catalist
	{
		private const int DefaultHealthEffect = 3;

		public HealthCatalyst()
			:base()
		{
			this.HealthEffect = HealthCatalyst.DefaultHealthEffect;
		}

	}
}
