using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
	public class Table : Furniture, FurnitureManufacturer.Interfaces.ITable
	{
		private decimal length;
		private decimal width;

		public Table(string initialModel, string initialMaterial, decimal initialPrice, decimal initialHeight, decimal initialLength, decimal initialWidth)
			: base(initialModel, initialMaterial, initialPrice, initialHeight)
		{
			this.Length = initialLength;
			this.Width = initialWidth;
		}

		public decimal Length
		{
			get
			{
				return this.length;
			}
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException("Length cannot be less or equal to 0.00 m.");

				this.length = value;
			}
		}

		public decimal Width
		{
			get
			{
				return this.width;
			}
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException("Width cannot be less or equal to 0.00 m.");

				this.width = value;
			}
		}

		public decimal Area
		{
			get { return this.Length * this.Width; }
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.Append(string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area));
			return info.ToString();
		}
	}
}
