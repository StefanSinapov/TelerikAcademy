using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Places.Models;
using Places.Repositories;
using Places.Services.Controllers;
using Places.DataLayer;
using System.Data.Entity;

namespace Places.Services.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext placesContext =  new PlacesContext();

        private static IRepository<Category> repository = new DbCategoryRepository(placesContext);


        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(CategoriesController))
            {
                return new CategoriesController(repository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}