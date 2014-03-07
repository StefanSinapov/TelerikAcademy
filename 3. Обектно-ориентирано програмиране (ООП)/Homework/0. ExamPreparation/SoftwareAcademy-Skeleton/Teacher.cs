using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
	public class Teacher : ITeacher
	{
		private string name;
		public IList<ICourse> Courses { get; set; }

		public Teacher(string initialName)
		{
			this.Name = initialName;
			this.Courses = new List<ICourse>();
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
					throw new ArgumentNullException("Teacher name cannot be null");
				this.name = value;
			}
		}

		public void AddCourse(ICourse course)
		{
			if (course == null)
				throw new ArgumentNullException("Course cannot be null!");
			this.Courses.Add(course);
		}

		public override string ToString()
		{
			string info;
			string coursesExist = string.Format("; Courses=[{0}]", string.Join(", ", this.Courses.Select((course) => course.Name)));
			string courses = this.Courses.Count == 0 ? string.Empty : coursesExist;
			info = string.Format("Teacher: Name={0}{1}", this.Name, courses);

			return info;
		}
	}
}
