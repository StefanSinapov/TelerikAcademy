namespace BunniesCraft.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Description;
    using BunniesCraft.Data;
    using BunniesCraft.Models;
    using System.Web.Mvc;
    using BunniesCraft.Services.Models;

    public class BunniesController : ApiController
    {
        private BunniesDbContext db = new BunniesDbContext();

        // GET: api/Bunnies
        public IQueryable<BunnyModel> GetBunnies()
        {
            return db.Bunnies.Select(b => new BunnyModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Health = b.Health,
                    ColorType = b.ColorType,
                    AirCraftId = b.AirCraftId
                });
        }

        // GET: api/Bunnies/5
        [ResponseType(typeof(Bunny))]
        public IHttpActionResult GetBunny(int id)
        {
            Bunny bunny = db.Bunnies.Find(id);
            if (bunny == null)
            {
                return NotFound();
            }

            return Ok(bunny);
        }

        // PUT: api/Bunnies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBunny(int id, Bunny bunny)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bunny.Id)
            {
                return BadRequest();
            }

            db.Entry(bunny).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BunnyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bunnies
        [ResponseType(typeof(Bunny))]
        public IHttpActionResult PostBunny(Bunny bunny)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bunnies.Add(bunny);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bunny.Id }, bunny);
        }

        // DELETE: api/Bunnies/5
        [ResponseType(typeof(Bunny))]
        public IHttpActionResult DeleteBunny(int id)
        {
            Bunny bunny = db.Bunnies.Find(id);
            if (bunny == null)
            {
                return NotFound();
            }

            db.Bunnies.Remove(bunny);
            db.SaveChanges();

            return Ok(bunny);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult ByAirCraftId(int id)
        {
            var bunnies = this.db.Bunnies.Where(b => b.AirCraftId == id).Select(b => new BunnyModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Health = b.Health,
                    ColorType = b.ColorType,
                    AirCraftId = b.AirCraftId
                });

            return Ok(bunnies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BunnyExists(int id)
        {
            return db.Bunnies.Count(e => e.Id == id) > 0;
        }
    }
}