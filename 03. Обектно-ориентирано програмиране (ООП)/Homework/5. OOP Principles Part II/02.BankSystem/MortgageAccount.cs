using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	public class MortgageAccount : Account, IDepositable
	{
		public MortgageAccount(Customer customer, decimal balance, decimal interest)
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
			if (this.customer == Customer.Company)
			{
				if (numberOfMonths < 12)
				{
					return base.CalculateInterest(numberOfMonths) / 2;
				}
				else
				{
					return base.CalculateInterest(12) / 2 + base.CalculateInterest(numberOfMonths - 12);
				}
			}
			else if (this.customer == Customer.Individual)
			{
				return base.CalculateInterest(numberOfMonths - 6);
			}
			else
			{
				throw new Exception("Invalid customer type");
			}
		}
	}
}
