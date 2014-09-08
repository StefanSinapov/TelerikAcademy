namespace ATM.Data.Contracts
{
    public interface ICardDataVerifier
    {
        bool VerifyPin(string pinCode, string acturalPin);

        bool VerityCardNumber(string cardNumber);

        bool VerifyCardBalance(decimal requestedSum, decimal actualSum);
    }
}