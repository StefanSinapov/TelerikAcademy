namespace MusicStore.WebAPI.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Data;
    using Data.Contracts;
    using DataModels;
    using Models;

    public class SongsController : BaseApiController
    {

        public SongsController()
            : this(new MusicStoreData(new MusicStoreDbContext()))
        {

        }

        protected SongsController(IMusicStoreData data)
            : base(data)
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var songs = this.Data.Songs.All().Select(SongDataModel.FromEntityToModel).ToList();

            return Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var song = this.Data.Songs.Find(id);

            if (song == null)
            {
                return BadRequest();
            }

            var songModel = new SongDataModel
            {
                Id = song.Id,
                AlbumId = song.AlbumId,
                Artists = song.Artists.AsQueryable().Select(ArtistDataModel.FromEntityToModel).ToList(),
                Genre = song.Genre,
                Title = song.Title,
                Year = song.Year
            };

            return Ok(songModel);
        }

        [HttpPost]
        public IHttpActionResult Create(SongDataModel model)
        {
            var song = new Song
            {
                AlbumId = model.AlbumId,
                Genre = model.Genre,
                Title = model.Title,
                Year = model.Year
            };

            try
            {
                this.Data.Songs.Add(song);
                this.Data.SaveChanges();
                model.Id = song.Id;
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(int id, SongDataModel model)
        {
            var song = this.Data.Songs.Find(id);

            if (song == null)
            {
                return NotFound();
            }

            song.Title = model.Title;
            song.Year = model.Year;
            song.Genre = model.Genre;
            song.AlbumId = model.AlbumId;

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
            var song = this.Data.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            try
            {
                this.Data.Songs.Delete(song);
                this.Data.SaveChanges();
                return Ok(song);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}