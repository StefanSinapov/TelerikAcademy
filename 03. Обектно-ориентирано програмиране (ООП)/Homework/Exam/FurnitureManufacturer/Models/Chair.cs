using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
	public class Chair : Furniture, FurnitureManufacturer.Interfaces.IChair
	{
		private int numberOfLegs;

		public Chair(string initialModel, string initialMaterial, decimal initialPrice, decimal initialHeight, int initialNumberOfLegs)
			:base(initialModel,initialMaterial,initialPrice,initialHeight)
		{
			this.numberOfLegs = initialNumberOfLegs;
		}

		public int NumberOfLegs
		{
			get
			{
				return this.numberOfLegs;
			}
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException("Number of legs cannot be equal or less than 0");
				this.numberOfLegs = value;
			}
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs));
			return info.ToString();
		}
	}
}
