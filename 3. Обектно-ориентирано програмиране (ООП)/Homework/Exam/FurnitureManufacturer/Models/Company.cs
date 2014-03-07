using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FurnitureManufacturer.Models
{
	public class Company : FurnitureManufacturer.Interfaces.ICompany
	{
		private string name;
		private string registrationNumber;
		private ICollection<Interfaces.IFurniture> furnitures;

		public Company(string initialName, string initialRegistrationNumber)
		{
			this.Furnitures = new List<Interfaces.IFurniture>();
			this.Name = initialName;
			this.RegistrationNumber = initialRegistrationNumber;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Name cannot be empty or null");
				if (value.Length < 5)
					throw new ArgumentOutOfRangeException("Name cannot be less than 5 symbols");
				this.name = value;
			}
		}

		public string RegistrationNumber
		{
			get
			{
				return this.registrationNumber;
			}
			set
			{
				if (!Regex.IsMatch(value, @"^\d{10}$"))
					throw new ArgumentException("Registration number must be exactly 10 symbols and must contain only digits");
				this.registrationNumber = value;
			}
		}

		public ICollection<Interfaces.IFurniture> Furnitures
		{
			get
			{
				return this.furnitures;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException("Furnitures cannot be null");
				this.furnitures = value;
			}
		}

		public void Add(Interfaces.IFurniture furniture)
		{
			if (furniture == null)
				throw new ArgumentNullException("Furniture cannot be null");
			this.Furnitures.Add(furniture);
		}

		public void Remove(Interfaces.IFurniture furniture)
		{
			if (furniture == null)
				throw new ArgumentNullException("Furniture cannot be null");
			this.Furnitures.Remove(furniture);
		}

		public Interfaces.IFurniture Find(string model)
		{
			if (string.IsNullOrEmpty(model))
				throw new ArgumentNullException("Searched furniture model cannot be null");
			return this.Furnitures.FirstOrDefault((furn) => furn.Model == model);
		}

		public string Catalog()
		{
			StringBuilder info = new StringBuilder();
			string furnituresCount=this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no";
			string furnituresWord=this.Furnitures.Count != 1 ? "furnitures" : "furniture";

			info.Append(string.Format("{0} - {1} - {2} {3}",this.Name,this.RegistrationNumber,furnituresCount,furnituresWord));
			
			if (this.Furnitures.Count > 0)
			{
				info.AppendLine();
				var sortedFurnitures = this.Furnitures.OrderBy((f) => f.Price).ThenBy((f) => f.Model);
				foreach (var furniture in sortedFurnitures)
				{
					info.AppendLine(furniture.ToString());
				}
			}
			return info.ToString().TrimEnd();
		}

	}
}
