using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University
{
	public class University
	{
		private readonly List<Class> classes;
		private string name = string.Empty;

		public University(string name)
		{
			this.Name = name;
			this.classes = new List<Class>();
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("University name cant be null or empty");
				this.name = value;
			}
		}

		public void AddClass(params Class[] classes)
		{
			foreach (var subject in classes)
			{
				this.classes.Add(subject);
			}
		}
		public void RemoveClass(Class subject)
		{
			this.classes.Remove(subject);
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.AppendLine(Name);
			info.AppendLine("	Classes:");
			if(this.classes.Count>0)
			{
				foreach (var subject in this.classes)
				{
					info.AppendLine("	" + subject);
				}
			}
			else
			{
				info.AppendLine("	(There is no classes yet)");
			}

			return info.ToString();
		}
	}
}
