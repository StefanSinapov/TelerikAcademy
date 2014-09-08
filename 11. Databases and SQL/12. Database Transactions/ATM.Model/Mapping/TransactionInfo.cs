namespace ATM.Models.Mapping
{
    public class TransactionInfo
    {
        public string CardNumber { get; set; }

        public string CardPin { get; set; }

        public decimal MoneyToRetrieve { get; set; }
    }
}