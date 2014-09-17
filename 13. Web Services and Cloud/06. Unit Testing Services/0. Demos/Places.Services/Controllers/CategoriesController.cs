using Places.Models;
using Places.Repositories;
using Places.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Places.Services.Controllers
{
    public class CategoriesController : ApiController
    {
        private IRepository<Category> categoriesRepository;

        public CategoriesController(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            var categoryEntities = this.categoriesRepository.All();
            var categoryModels =
                                from catEntity in categoryEntities
                                select new CategoryModel()
                                {
                                    Id = catEntity.Id,
                                    Name = catEntity.Name
                                };
            return categoryModels.ToList();
        }

        public CategoryDetails GetSingle(int id)
        {
            var entity = this.categoriesRepository.Get(id);
            var model = new CategoryDetails()
            {
                Id = entity.Id,
                Name = entity.Name,
                Places = (from place in entity.Places
                          select new PlaceModel()
                          {
                              Id = place.Id,
                              Name = place.Name,
                              Latitude = place.Latitude,
                              Longitude = place.Longitude
                          }).ToList()
            };

            return model;
        }

        public HttpResponseMessage PostCategory(CategoryModel model)
        {
            var entityToAdd = new Category()
            {
                Name = model.Name
            };

            var createdEntity = this.categoriesRepository.Add(entityToAdd);


            var createdModel = new CategoryModel()
            {
                Id = createdEntity.Id,
                Name = createdEntity.Name
            };

            var response = Request.CreateResponse<CategoryModel>(HttpStatusCode.Created, createdModel);
            var resourceLink = Url.Link("DefaultApi", new { id = createdModel.Id });

            response.Headers.Location = new Uri(resourceLink);
            return response;
        }
    }
}