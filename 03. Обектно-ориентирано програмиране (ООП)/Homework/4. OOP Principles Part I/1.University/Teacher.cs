using System;
using System.Collections.Generic;
using System.Text;

namespace University
{
	public class Teacher : People, IEquatable<Teacher>, ICommentable, IComparable<Teacher>
	{
		//Fields
		private List<Discipline> disciplines = new List<Discipline>();
		public string Comment { get; set; }

		public Teacher(string firstName, string lastName)
			: base(firstName, lastName)
		{

		}

		//Methods
		public void AddDiscipline(params Discipline[] disciplines)
		{
			foreach (var discipline in disciplines)
			{
				this.disciplines.Add(discipline);
			}
		}
		public void RemoveDiscipline(Discipline discipline)
		{
			this.disciplines.Remove(discipline);
		}
		public bool Equals(Teacher other)
		{
			if (this.FirstName == other.FirstName && this.LastName == other.LastName)
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
			info.AppendLine(base.ToString());

			if (this.disciplines.Count > 0)
			{
				info.AppendLine("		Disciplines:");
				foreach (var discipline in this.disciplines)
				{
					info.AppendLine("			" + discipline);
				}
			}
			return info.ToString();
		}

		public int CompareTo(Teacher other)
		{
			return this.FirstName.CompareTo(other.FirstName);
		}
	}
}
