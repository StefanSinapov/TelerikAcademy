using System;

namespace AnimalFarm
{
	public abstract class Animal
	{
		private string name = string.Empty;
		private byte age;
		public Gender Sex { get; set; }

		public Animal(string name, byte age, Gender sex)
		{
			this.Name = name;
			this.Age = age;
			this.Sex = sex;
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Name cant be null or empty");
				this.name = value;
			}
		}
		public byte Age
		{
			get { return this.age; }
			set
			{
				if (value < 0 || value > 100)
					throw new ArgumentOutOfRangeException("Age must be positive and less than 100");
				this.age = value;
			}
		}

		public abstract string Sound();
	}
}
