using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftwareAcademy
{
	public abstract class Course : ICourse
	{
		private string name;
		//private List<string> topics;


		public Course(string initialName, ITeacher initialTeacher = null)
		{
			this.Name = initialName;
			this.Teacher = initialTeacher;
			this.Topics = new List<string>();
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
					throw new ArgumentNullException("Course cannot be null");
				this.name = value;
			}
		}

		public List<string> Topics { get; set; }

		public ITeacher Teacher { get; set; }

		public void AddTopic(string topic)
		{
			if (string.IsNullOrEmpty(topic))
				throw new ArgumentNullException("Topic cannot be null");
			this.Topics.Add(topic);
		}

		public override string ToString()
		{
			StringBuilder info = new StringBuilder();

			info.Append(string.Format("Name={0}", this.Name));
			if(this.Teacher!=null)
			{
				info.Append(string.Format("; Teacher={0}", this.Teacher.Name));
			}
			if (this.Topics.Count > 0)
			{
				info.Append(string.Format("; Topics=[{0}]", string.Join(", ", this.Topics)));
			}

			return info.ToString();
		}
	}
}
