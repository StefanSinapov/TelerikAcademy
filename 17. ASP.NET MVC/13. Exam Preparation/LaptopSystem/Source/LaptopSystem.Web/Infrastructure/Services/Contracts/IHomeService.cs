namespace LaptopSystem.Web.Infrastructure.Services.Contracts
{
    using System.Collections.Generic;

    using LaptopSystem.Web.ViewModels.Laptops;

    public interface IHomeService
    {
        IList<LaptopViewModel> GetIndexViewModel(int number);
    }
}