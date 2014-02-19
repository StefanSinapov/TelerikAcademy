using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
	public class Student : People, IEquatable<Student>, ICommentable, IComparable<Student>
	{
		//Fields
		public string ClassNumber { get; set; }
		private List<Class> classes = new List<Class>();
		public string Comment { get; set; }

		//Constructor
		public Student(string firstName, string lastName, string classNumber):base(firstName,lastName)
		{
			this.ClassNumber = classNumber;
		}

		//Methods
		public Student AddClass(Class subject)
		{
			this.classes.Add(subject);
			return this;
		}
		public void RemoveClass(Class subject)
		{
			this.classes.Remove(subject);
		}
		public bool Equals(Student other)
		{
			if(this.FirstName==other.FirstName && this.LastName==other.LastName && this.ClassNumber==other.ClassNumber)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.Append(string.Format("{0} {1}",base.ToString(), this.ClassNumber));
			//if(this.classes.Count>0)
			//{
			//	info.AppendLine("	Classes:");
			//	foreach (var subject in this.classes)
			//	{
			//		info.AppendLine("	" + subject);
			//	}
			//}
			return info.ToString();
		}

		public int CompareTo(Student other)
		{
			return this.ClassNumber.CompareTo(other.ClassNumber);
		}
	}
}
