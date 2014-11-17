namespace LaptopSystem.Web.Areas.Admin.Controllers
{
    using System.Collections;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Kendo.Mvc.UI;

    using LaptopSystem.Data.UnitOfWork;
    using LaptopSystem.Web.Areas.Admin.Controllers.Base;

    using Model = LaptopSystem.Data.Models.Laptop;
    using ViewModel = LaptopSystem.Web.Areas.Admin.ViewModels.Laptops.LaptopViewModel;

    public class LaptopsController : KendoGridAdminController
    {
        public LaptopsController(ILaptopSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
       
        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            var dataModel = base.Create<Model>(model);
            if (dataModel != null)
            {
                model.Id = dataModel.Id;
            }

            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, ViewModel model)
        {
            base.Update<Model, ViewModel>(model, model.Id);
            return this.GridOperation(model, request);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, ViewModel model)
        {
            return this.GridOperation(model, request);
        }


        protected override IEnumerable GetData()
        {
            return this.Data.Laptops.All().Project().To<ViewModel>();
        }

        protected override T GetById<T>(object id)
        {
            return this.Data.Laptops.Find(id) as T;
        }   
    }
}