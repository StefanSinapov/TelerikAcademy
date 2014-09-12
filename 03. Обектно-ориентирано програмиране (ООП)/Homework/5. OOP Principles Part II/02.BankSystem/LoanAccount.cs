using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	public class LoanAccount : Account, IDepositable
	{
		public LoanAccount(Customer customer, decimal balance, decimal interest)
			: base(customer, balance, interest)
		{

		}
		public void Deposit(decimal depositAmount)
		{
			this.Balance += depositAmount;
			Console.WriteLine("{0} deposit, current balance: {1}", depositAmount, Balance);
		}
		public override decimal CalculateInterest(int numberOfMonths)
		{
			if (this.customer == Customer.Individual)
			{
				return base.CalculateInterest(numberOfMonths - 3);
			}
			else if (this.customer == Customer.Company)
			{
				return base.CalculateInterest(numberOfMonths - 2);
			}
			else
			{
				throw new Exception("Invalid customer type!");
			}
		}
	}
}
