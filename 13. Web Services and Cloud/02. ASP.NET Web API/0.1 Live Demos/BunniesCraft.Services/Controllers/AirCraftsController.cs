namespace BunniesCraft.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using BunniesCraft.Data;
    using BunniesCraft.Data.Repositories;
    using BunniesCraft.Models;
    using BunniesCraft.Services.Models;

    public class AirCraftsController : ApiController
    {
        private IBunniesData data;

        public AirCraftsController()
            : this(new BunniesData())
        {
        }

        public AirCraftsController(IBunniesData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var aircrafts = this.data
                .AirCrafts
                .All()
                .Select(AirCraftModel.FromAirCraft);

            return Ok(aircrafts);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var airCraft = this.data
                .AirCrafts
                .All()
                .Where(a => a.Id == id)
                .Select(AirCraftModel.FromAirCraft)
                .FirstOrDefault();

            if (airCraft == null)
            {
                return BadRequest("AirCraft does not exist - invalid id");
            }

            return Ok(airCraft);
        }

        [HttpPost]
        public IHttpActionResult Create(AirCraftModel airCraft)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAirCraft = new AirCraft
            {
                Model = airCraft.Model
            };

            this.data.AirCrafts.Add(newAirCraft);
            this.data.SaveChanges();

            airCraft.Id = newAirCraft.Id;
            return Ok(airCraft);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AirCraftModel airCraft)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingAirCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
            if (existingAirCraft == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            existingAirCraft.Model = airCraft.Model;
            this.data.SaveChanges();

            airCraft.Id = id;
            return Ok(airCraft);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingAirCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
            if (existingAirCraft == null)
            {
                return BadRequest("Such aircraft does not exists!");
            }

            this.data.AirCrafts.Delete(existingAirCraft);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddBunny(int id, int bunnyId)
        {
            var airCraft = this.data.AirCrafts.All().FirstOrDefault(a => a.Id == id);
            if (airCraft == null)
            {
                return BadRequest("Such aircraft does not exists - invalid id!");
            }

            var bunny = this.data.Bunnies.All().FirstOrDefault(b => b.Id == bunnyId);
            if (bunny == null)
            {
                return BadRequest("Such bunny does not exists - invalid id!");
            }

            airCraft.Bunnies.Add(bunny);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
