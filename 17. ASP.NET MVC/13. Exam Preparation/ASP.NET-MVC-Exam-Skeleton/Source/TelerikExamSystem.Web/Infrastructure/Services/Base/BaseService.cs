namespace TelerikExamSystem.Web.Services.Base
{
    using TelerikExamSystem.Data.UnitOfWork;

    public abstract class BaseService
    {
        protected BaseService(ITelerikExamSystemData data)
        {
            this.Data = data;
        }

        public ITelerikExamSystemData Data { get; set; }
    }
}