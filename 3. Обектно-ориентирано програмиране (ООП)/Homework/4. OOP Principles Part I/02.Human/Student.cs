using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Human
{
	public class Student : Human
	{
		private uint grade;

		public Student(string firstName, string lastName, uint grade)
			: base(firstName, lastName)
		{
			this.Grade = grade;
		}

		public uint Grade
		{
			get { return this.grade; }
			set
			{
				if (value < 2 && value > 6)
					throw new ArgumentOutOfRangeException("Grade must be between 2 and 6");
				this.grade = value;
			}
		}

		public override string ToString()
		{
			return string.Format("{0} {1} - {2}", this.FirstName, this.LastName, this.Grade);
		}
	}
}
