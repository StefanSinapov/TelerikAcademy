using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
	public class Circle : Shape
	{
		public Circle(double diameter)
			:base(diameter,diameter)
		{

		}
		public override double CalculateSurface()
		{
			return (this.Width / 2) * (this.Width / 2) * Math.PI;
		}
	}
}
