using System;

namespace University
{
	public class People : IEquatable<People>
	{
		private string firstName = string.Empty;
		private string lastName = string.Empty;

		public People(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				if (value == null || value.Length < 3)
					throw new ArgumentException("Name cant be null or less than three symbols");
				lastName = value;
			}
		}

		public string FirstName
		{
			get { return firstName; }
			set
			{
				if (value == null || value.Length < 3)
					throw new ArgumentException("Name cant be null or less than three symbols");
				firstName = value;
			}
		}


		public bool Equals(People other)
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
			return string.Format("{0} {1}", this.FirstName, this.LastName);
		}
	}
}
