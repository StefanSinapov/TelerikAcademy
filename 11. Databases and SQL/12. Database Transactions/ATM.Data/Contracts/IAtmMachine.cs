namespace ATM.Data.Contracts
{
    using Models.Mapping;

    public interface IAtmMachine
    {
        void RetrieveMoney(TransactionInfo tranInfo);
    }
}