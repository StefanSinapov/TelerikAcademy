using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
	public class LocalCourse : Course, ILocalCourse
	{
		private string lab;

		public LocalCourse(string initialName, ITeacher initialTeacher, string initialLab)
			: base(initialName,initialTeacher)
		{
			this.Lab = initialLab;
		}

		public string Lab
		{
			get
			{
				return this.lab;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Lab cannot be null");
				this.lab = value;
			}
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();
			info.Append("LocalCourse: ");
			info.Append(base.ToString());
			info.Append(string.Format("; Lab={0}", this.Lab));

			return info.ToString();
		}
	}
}
