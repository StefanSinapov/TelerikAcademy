using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
	public class OffsiteCourse : Course, IOffsiteCourse
	{
		private string town;

		public OffsiteCourse(string initialName, ITeacher teacher, string initialTown)
			:base(initialName,teacher)
		{
			this.Town = initialTown;
		}

		public string Town
		{
			get
			{
				return this.town;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Town cannot be null");
				this.town = value;
			}
		}

		public override string ToString()
		{
			string info = string.Format("OffsiteCourse: {0}; Town={1}", base.ToString(), this.Town);
			return info;
		}

	}
}
