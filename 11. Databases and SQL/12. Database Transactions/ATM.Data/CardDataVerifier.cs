namespace ATM.Data
{
    using Contracts;

    public class CardDataVerifier: ICardDataVerifier
    {
        private const int CardNumberLength = 10;
        private const int CardPinLength = 4;

        public bool VerifyPin(string pinCode, string acturalPin)
        {
            if (string.IsNullOrWhiteSpace(pinCode))
            {
                return false;
            }
            return IsValidPinCode(pinCode, acturalPin) && IsValidPinLength(pinCode);
        }

        private bool IsValidPinCode(string pinCode, string acturalPin)
        {
            return pinCode == acturalPin;
        }

        private bool IsValidPinLength(string pinCode)
        {
            return pinCode.Length == CardPinLength;
        }

        public bool VerityCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                return false;
            }

            bool isvalidCardNumber = cardNumber.Length == CardNumberLength;
            return isvalidCardNumber;
        }

        public bool VerifyCardBalance(decimal requestedSum, decimal actualSum)
        {
            var isPermittedWithdrawalAmount = requestedSum > 0 && actualSum >= requestedSum;
            return isPermittedWithdrawalAmount;
        }
    }
}