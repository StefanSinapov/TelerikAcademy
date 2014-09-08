/*
 * 2. Using transactions write a method which retrieves some money 
 * (for example $200) from certain account. 
 * The retrieval is successful when the following sequence of 
 * sub-operations is completed successfully:
	- A query checks if the given CardPIN and CardNumber are valid.
	- The amount on the account (CardCash) is evaluated to see whether 
        it is bigger than the requested sum (more than $200).
	- The ATM machine pays the required sum (e.g. $200) and stores 
        in the table CardAccounts the new amount (CardCash = CardCash - 200`).
	- Why does the isolation level need to be set to “repeatable read”?
 */

/*
 * Extend the project from the previous exercise and add 
 * a new table TransactionsHistory with 
 * fields (Id, CardNumber, TransactionDate, Ammount) 
 * containing information about all money retrievals on all accounts.
	
 * Modify the program logic so that it saves historical information 
 * (logs) in the new table after each successful money withdrawal.
	What should the isolation level be for the transaction?
 * 
 * >>>>>> See AtmMachine Class
 */
namespace ATM.ConsoleClient
{
    using System;
    using System.Linq;
    using Data;
    using Models.Mapping;

    public class EntryPoint
    {
        private static readonly AtmMachine Atm = new AtmMachine();

        public static void Main()
        {
            var db = new AtmData();
            using (db)
            {
                Console.WriteLine("Connecting to SQL Server...");

                //valid data
                PerformeTransaction(new TransactionInfo
                {
                    CardNumber = "111-222-33",
                    CardPin = "0000",
                    MoneyToRetrieve = 10
                });

                //Invalid CardNumber
                PerformeTransaction(new TransactionInfo
                {
                    CardNumber = "111-22222-33",
                    CardPin = "0000",
                    MoneyToRetrieve = 200
                });

                //Invalid Pin
                PerformeTransaction(new TransactionInfo
                {
                    CardNumber = "111-222-33",
                    CardPin = "1234125",
                    MoneyToRetrieve = 200
                });

                //Uncorrected Pin 
                PerformeTransaction(new TransactionInfo
                {
                    CardNumber = "111-222-33",
                    CardPin = "00001",
                    MoneyToRetrieve = 200
                });

                //Invalid MoneyToRetrieve
                PerformeTransaction(new TransactionInfo
                {
                    CardNumber = "111-222-33",
                    CardPin = "0000",
                    MoneyToRetrieve = 200
                });



                Console.WriteLine("\nTransaction Histories:");
                var histories = db.TransactionHistories.All().ToList();
                foreach (var transactionsHistory in histories)
                {
                    Console.WriteLine("{0} - from {1} - Ammount: {2}", 
                                    transactionsHistory.TransactionDate, 
                                    transactionsHistory.CardNumber, 
                                    transactionsHistory.Ammount);
                }
            }
        }

        private static void PerformeTransaction(TransactionInfo tranInfo)
        {
            try
            {
                Atm.RetrieveMoney(tranInfo);
                Console.WriteLine("Transaction Succeed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Transaction Failed: {0}", e.Message);
            }
        }
    }
}
