using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
	public abstract class Furniture : FurnitureManufacturer.Interfaces.IFurniture
	{
		private string model;
		private string material;
		private decimal price;
		private decimal height;

		public Furniture(string initialModel, string initialMaterial, decimal initialPrice, decimal initialHeight)
		{
			this.Model = initialModel;
			this.Material = initialMaterial;
			this.Price = initialPrice;
			this.Height = initialHeight;
		}

		public string Model
		{
			get
			{
				return this.model;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Furniture model cannot be null");
				if (value.Length < 3)
					throw new ArgumentException("Furniture model cannot be less than 3 symbols");
				this.model = value;
			}
		}

		public string Material
		{
			get
			{
				return this.material;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Material cannot be null");
				this.material = value;
			}
		}

		public decimal Price
		{
			get
			{
				return this.price;
			}
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException("Price cannot be less or equal to $0.00.");
				this.price = value;
			}
		}

		public decimal Height
		{
			get
			{
				return this.height;
			}
			set
			{
				if (value <= 0)
					throw new ArgumentOutOfRangeException("Height cannot be less or equal to 0.00 m.");
				this.height = value;
			}
		}

		
	}
}
