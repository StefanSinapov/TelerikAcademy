using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Human
{
	public class Worker : Human
	{
		private decimal weekSalary;
		private byte workHoursPerDay;

		public Worker(string firstName, string lastName, Decimal weekSalary, byte workHoursPerDay)
			: base(firstName, lastName)
		{
			this.WeekSalary = weekSalary;
			this.WorkHoursPerDay = workHoursPerDay;
		}

		public decimal WeekSalary
		{
			get { return this.weekSalary; }
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Salary must be positive number");
				this.weekSalary = value;
			}
		}
		public byte WorkHoursPerDay
		{
			get { return this.workHoursPerDay; }
			set
			{
				if (value < 0 && value > 24)
					throw new ArgumentOutOfRangeException("Work hours per day must be positive and less than 24 hours");
				this.workHoursPerDay = value;
			}
		}
		public decimal MoneyPerHour()
		{
			return Math.Round((this.weekSalary / (5 * this.workHoursPerDay)),2);
		}

		public override string ToString()
		{
			return string.Format("{0} {1} - {2}", this.FirstName, this.LastName, this.MoneyPerHour());
		}

	}
}
