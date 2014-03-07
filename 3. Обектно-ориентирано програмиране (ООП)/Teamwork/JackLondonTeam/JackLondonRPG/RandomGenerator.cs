using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackLondonRPG
{
	public static class RandomGenerator
	{
		private static Random random = new Random();

		public static Random  Random
		{
			get { return random; }
		}
	}
}
