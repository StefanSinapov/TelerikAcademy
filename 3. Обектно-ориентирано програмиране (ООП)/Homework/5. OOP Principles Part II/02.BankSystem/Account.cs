using System;

namespace BankSystem
{
	public abstract class Account
	{
		protected Customer customer;
		public decimal Balance { get; protected set; }
		public decimal InterestRate { get; protected set; }

		public Account(Customer customer,decimal balance, decimal interestRate)
		{
			this.customer = customer;
			this.Balance = balance;
			this.InterestRate = interestRate;
		}

		public virtual decimal CalculateInterest(int numberOfMonths)
		{
			return numberOfMonths > 0 ? numberOfMonths * this.InterestRate : 0;
		}
	}
}
