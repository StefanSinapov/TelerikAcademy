using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace University
{
	public class Class : ICommentable, IEquatable<Class>
	{
		private SortedSet<Student> students;
		private SortedSet<Teacher> teachers;
		private string name = string.Empty;
		public string Comment { get; set; }

		public Class(string name)
		{
			this.students = new SortedSet<Student>();
			this.teachers = new SortedSet<Teacher>();
			this.Name = name;
		}

		public string Name
		{
			get { return this.name; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Class ID cant be null or empty");
				this.name = value;
			}
		}

		public void AddStudent(params Student[] students)
		{
			foreach(var student in students)
			{
				this.students.Add(student);
			}
		}
		public void RemoveStudent(Student student)
		{
			this.students.Remove(student);
		}
		public void AddTeacher(params Teacher[] teachers)
		{
			foreach(var teacher in teachers)
			{
				this.teachers.Add(teacher);
			}
		}
		public void RemoveTeacher(Teacher teacher)
		{
			this.teachers.Remove(teacher);
		}
		public bool Equals(Class other)
		{
			return this.Name.Equals(other.Name);
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.AppendLine(string.Format("Class: {0}", this.Name));

			if(this.teachers.Count>0)
			{
				info.AppendLine("		Teachers:");
				foreach (var teacher in this.teachers)
				{
					info.AppendLine("		" + teacher);
				}
			}
			if(this.students.Count>0)
			{
				info.AppendLine("		Students:");
				foreach (var student in this.students)
				{
					info.AppendLine("		" + student);
				}
			}

			return info.ToString();
		}

		internal void AddStudent(List<Student> students)
		{
			foreach (var student in students)
			{
				this.students.Add(student);
			}
		}
	}
}
