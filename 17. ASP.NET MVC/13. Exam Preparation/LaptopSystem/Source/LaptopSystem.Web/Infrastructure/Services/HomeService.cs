namespace LaptopSystem.Web.Infrastructure.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using LaptopSystem.Data.UnitOfWork;
    using LaptopSystem.Web.Infrastructure.Services.Base;
    using LaptopSystem.Web.Infrastructure.Services.Contracts;
    using LaptopSystem.Web.ViewModels.Laptops;

    public class HomeService : BaseService, IHomeService
    {
        public HomeService(ILaptopSystemData data)
            : base(data)
        {
        }

        public IList<LaptopViewModel> GetIndexViewModel(int number)
        {
            return this.Data.Laptops.All()
                    .OrderByDescending(l => l.Votes.Count)
                    .Take(number)
                    .Project()
                    .To<LaptopViewModel>()
                    .ToList();
        }
    }
}