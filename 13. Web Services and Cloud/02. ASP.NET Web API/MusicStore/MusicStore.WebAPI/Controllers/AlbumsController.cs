namespace MusicStore.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using Models;

    public class AlbumsController : BaseApiController
    {
        public AlbumsController()
            : this(new MusicStoreData(new MusicStoreDbContext()))
        {
            
        }

        protected AlbumsController(IMusicStoreData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var artists = this.Data.Albums.All().Select(AlbumDataModel.FromEntityToModel).ToList();

            return Ok(artists);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var album = this.Data.Albums.Find(id);

            if (album == null)
            {
                return NotFound();
            }

            var model = new AlbumDataModel
            {
                Id = album.Id,
                Songs = album.Songs.AsQueryable().Select(SongDataModel.FromEntityToModel).ToArray(),
                Artists = album.Artists.AsQueryable().Select(ArtistDataModel.FromEntityToModel).ToArray(),
                Year = album.Year,
                Title = album.Title,
                Producer = album.Producer
            };

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumDataModel model)
        {
            var album = new Album
            {
                Producer = model.Producer,
                Year = model.Year,
                Title = model.Title
            };

            try
            {
                this.Data.Albums.Add(album);
                this.Data.SaveChanges();

                model.Id = album.Id;
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, AlbumDataModel model)
        {
            var album = this.Data.Albums.Find(id);

            if (album == null)
            {
                return NotFound();
            }

            album.Title = model.Title;
            album.Year = model.Year;
            album.Producer = model.Producer;

            try
            {
                this.Data.SaveChanges();
                model.Id = album.Id;
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
            var album = this.Data.Albums.Find(id);
            if (album == null)
            {
                return NotFound();
            }

            try
            {
                this.Data.Albums.Delete(album);
                this.Data.SaveChanges();
                return Ok(album);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}