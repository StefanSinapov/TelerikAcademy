using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
	public class AdjustableChair : Chair, FurnitureManufacturer.Interfaces.IAdjustableChair
	{
		public AdjustableChair(string initialModel, string initialMaterial, decimal initialPrice, decimal initialHeight, int initialNumberOfLegs)
			: base(initialModel, initialMaterial, initialPrice, initialHeight, initialNumberOfLegs)
		{

		}

		public void SetHeight(decimal height)
		{
			if (height <= 0)
				throw new ArgumentOutOfRangeException("Set height cannot be null, smaller or equal to 0");
			this.Height = height;
		}
	}
}
