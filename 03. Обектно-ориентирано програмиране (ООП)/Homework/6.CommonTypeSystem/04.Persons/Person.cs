using System;
using System.Text;
namespace Persons
{
	public class Person
	{
		private string name;
		public uint? Age { get; set; }

		public Person(string name, uint? age=null)
		{
			this.Name = name;
			this.Age = age;
		}

		public string Name
		{
			get { return name; }
			set 
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Name cannot be null");
				name = value; 
			}
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			string ageAsString = Age != null ? this.Age.ToString() : "not specified";
			info.AppendLine(string.Format("Name: {0}",this.Name));
			info.AppendLine(string.Format("Age: {0}",ageAsString));
			return info.ToString();
		}
	}
}
