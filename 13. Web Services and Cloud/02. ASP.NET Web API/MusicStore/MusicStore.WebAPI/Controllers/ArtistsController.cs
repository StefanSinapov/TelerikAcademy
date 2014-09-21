namespace MusicStore.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using Models;

    public class ArtistsController : BaseApiController
    {
        public ArtistsController()
            : this(new MusicStoreData(new MusicStoreDbContext()))
        {

        }

        protected ArtistsController(IMusicStoreData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.Data.Artists.All().Select(ArtistDataModel.FromEntityToModel).ToList();

            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var artist = this.Data.Artists.Find(id);

            if (artist == null)
            {
                return NotFound();
            }

            var model = new ArtistDataModel
            {
                Id = artist.Id,
                Albums = artist.Albums.AsQueryable().Select(AlbumDataModel.FromEntityToModel).ToArray(),
                Songs = artist.Songs.AsQueryable().Select(SongDataModel.FromEntityToModel).ToArray(),
                County = artist.County,
                DateOfBirth = artist.DateOfBirth,
                Name = artist.Name
            };

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistDataModel model)
        {
            var artist = new Artist
            {
                County = model.County,
                Name = model.Name,
                DateOfBirth = model.DateOfBirth
            };

            try
            {
                this.Data.Artists.Add(artist);
                this.Data.SaveChanges();

                model.Id = artist.Id;
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, ArtistDataModel model)
        {
            var artist = this.Data.Artists.Find(id);

            if (artist == null)
            {
                return NotFound();
            }

            artist.Name = model.Name;
            artist.County = artist.County;
            artist.DateOfBirth = artist.DateOfBirth;

            try
            {
                this.Data.SaveChanges();
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artist = this.Data.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }

            try
            {
                this.Data.Artists.Delete(artist);
                this.Data.SaveChanges();
                return Ok(artist);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}