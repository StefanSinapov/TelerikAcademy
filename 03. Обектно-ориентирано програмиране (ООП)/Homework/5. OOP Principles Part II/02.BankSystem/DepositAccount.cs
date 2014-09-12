using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	public class DepositAccount : Account,IDepositable, IWithdrawable
	{
		public DepositAccount(Customer customer,decimal balance, decimal interest)
			:base(customer,balance,interest)
		{

		}


		public void Deposit(decimal depositAmount)
		{
			Balance += depositAmount;
			Console.WriteLine("{0} deposit, current balance: {1}", depositAmount, Balance);
		}

		public void Withdraw(decimal withdrawAmount)
		{
			Balance -= withdrawAmount;
			Console.WriteLine("{0} withdrawn, current balance: {1}", withdrawAmount, Balance);
		}

		public override decimal CalculateInterest(int numberOfMonths)
		{
			if (this.Balance > 0 && this.Balance < 1000)
			{
				return 0;
			}
			else
			{
				return base.CalculateInterest(numberOfMonths);
			}
		}
	}
}
