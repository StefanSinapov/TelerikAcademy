using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
	public class ConvertibleChair : Chair, FurnitureManufacturer.Interfaces.IConvertibleChair
	{
		private readonly decimal InitialHeight;
		private const decimal DefaultConvertedHeight = 0.10m;

		public ConvertibleChair(string initialModel, string initialMaterial, decimal initialPrice, decimal initialHeight, int initialNumberOfLegs)
			: base(initialModel, initialMaterial, initialPrice, initialHeight, initialNumberOfLegs)
		{
			this.IsConverted = false;
			if (initialHeight <= 0)
				throw new ArgumentOutOfRangeException("Height cannot be less or equal to 0.00 m.");
			this.InitialHeight = initialHeight;
		}

		public bool IsConverted { get; private set; }

		public void Convert()
		{
			if (IsConverted == false)
			{
				this.IsConverted = true;
				this.Height = DefaultConvertedHeight;

			}
			else
			{
				this.IsConverted = false;
				this.Height = this.InitialHeight;
			}
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs, this.IsConverted ? "Converted" : "Normal"));
			return info.ToString();
		}
	}
}
