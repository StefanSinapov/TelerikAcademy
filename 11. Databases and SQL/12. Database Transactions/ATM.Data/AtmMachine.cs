namespace ATM.Data
{
    using System;
    using System.Data;
    using System.Linq;
    using Contracts;
    using Models;
    using Models.Mapping;

    public class AtmMachine : IAtmMachine
    {

        public AtmMachine()
        {
            this.CardDataVerifier = new CardDataVerifier();
            this.AtmContext = new AtmContext();
        }

        private AtmContext AtmContext { get; set; }

        private TransactionInfo TranInfo { get; set; }

        private ICardDataVerifier CardDataVerifier { get; set; }

        public void RetrieveMoney(TransactionInfo tranInfo)
        {
            this.TranInfo = tranInfo;

            using (var transaction = this.AtmContext.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    if (!this.CardDataVerifier.VerityCardNumber(this.TranInfo.CardNumber))
                    {
                        throw new ArgumentException("Invalid card number");
                    }

                    var cardAccount = this.AtmContext.CardAccounts
                        .FirstOrDefault(c => c.CardNumber == tranInfo.CardNumber);

                    if (cardAccount == null)
                    {
                        throw new ArgumentException("There is no such card");
                    }

                    if (!this.CardDataVerifier.VerifyPin(this.TranInfo.CardPin, cardAccount.CardPin))
                    {
                        throw new ArgumentException("Invalid pin code");
                    }

                    if (!this.CardDataVerifier.VerifyCardBalance(this.TranInfo.MoneyToRetrieve, cardAccount.CardCash))
                    {
                        throw new ArgumentException("Not enough money in account");
                    }

                    cardAccount.CardCash -= this.TranInfo.MoneyToRetrieve;
                    transaction.Commit();
                    AddTransactionHistory();
                    this.AtmContext.SaveChanges();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }

        private void AddTransactionHistory()
        {
            var tranHistory = new TransactionsHistory()
            {
                Ammount = this.TranInfo.MoneyToRetrieve,
                CardNumber = this.TranInfo.CardNumber,
                TransactionDate = DateTime.Now
            };

            this.AtmContext.TransactionsHistories.Add(tranHistory);
        }
    }
}