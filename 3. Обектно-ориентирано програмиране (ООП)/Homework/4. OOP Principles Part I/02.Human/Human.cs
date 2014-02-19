using System;
using System.Collections.Generic;
using System.Text;

namespace Human
{
	public abstract class Human
	{
		private string firstName = string.Empty;
		private string lastName = string.Empty;

		public Human(string firstName, string lastName)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		public string FirstName
		{
			get { return this.firstName; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("First name cant be null or empty");
				this.firstName = value;
			}
		}

		public string LastName
		{
			get { return this.lastName; }
			set
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Last name cant be null or empty");
				this.lastName = value;
			}
		}
	}
}
