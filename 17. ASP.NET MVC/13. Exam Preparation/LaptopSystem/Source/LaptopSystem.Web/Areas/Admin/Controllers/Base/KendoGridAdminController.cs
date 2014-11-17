namespace LaptopSystem.Web.Areas.Admin.Controllers.Base
{
    using System.Collections;
    using System.Data.Entity;
    using System.Web.Mvc;

    using AutoMapper;

    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    using LaptopSystem.Data.UnitOfWork;

    public abstract class KendoGridAdminController : AdminController
    {
        protected KendoGridAdminController(ILaptopSystemData data)
            : base(data)
        {
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest]
                                 DataSourceRequest request)
        {
            var data = this.GetData()
                           .ToDataSourceResult(request);

            return this.Json(data);
        }

        protected abstract IEnumerable GetData();

        protected abstract T GetById<T>(object id) where T : class;

        [NonAction]
        protected virtual T Create<T>(object model) where T : class
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dataModel = Mapper.Map<T>(model);
                this.ChangeEntityStateAndSave(dataModel, EntityState.Added);
                return dataModel;
            }

            return null;
        }

        [NonAction]
        protected virtual void Update<TModel, TViewModel>(TViewModel model, object id)
            where TModel : class
            where TViewModel : class
        {
            if (model != null && this.ModelState.IsValid)
            {
                var dataModel = this.GetById<TModel>(id);
                Mapper.Map(model, dataModel);
                this.ChangeEntityStateAndSave(dataModel, EntityState.Modified);
            }
        }

        protected JsonResult GridOperation<T>(T model, [DataSourceRequest] DataSourceRequest request)
        {
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        private void ChangeEntityStateAndSave(object dataModel, EntityState state)
        {
            var entry = this.Data.Context.Entry(dataModel);
            entry.State = state;
            this.Data.SaveChanges();
        }
    }
}