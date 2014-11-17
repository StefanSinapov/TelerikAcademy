namespace LaptopSystem.Web.Infrastructure.Services.Base
{
    using LaptopSystem.Data.UnitOfWork;

    public abstract class BaseService
    {
        protected BaseService(ILaptopSystemData data)
        {
            this.Data = data;
        }

        public ILaptopSystemData Data { get; set; }
    }
}