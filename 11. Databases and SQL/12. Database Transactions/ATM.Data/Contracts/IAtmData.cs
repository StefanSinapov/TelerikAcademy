namespace ATM.Data.Contracts
{
    using System;
    using Models;

    public interface IAtmData : IDisposable
    {
        IGenericRepository<CardAccount> CardAccounts { get; }

        int SaveChanges();
    }
}