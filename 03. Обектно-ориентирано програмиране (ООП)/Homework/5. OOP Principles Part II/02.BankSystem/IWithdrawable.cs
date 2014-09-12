using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
	interface IWithdrawable
	{
		void Withdraw(decimal withdrawAmount);
	}
}
