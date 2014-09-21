namespace MusicStore.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public class SongDataModel
    {

        public static Expression<Func<Song, SongDataModel>> FromEntityToModel
        {
            get
            {
                return song => new SongDataModel
                {
                    Id = song.Id,
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre,
                    Artists = song.Artists.AsQueryable().Select(ArtistDataModel.FromEntityToModel).ToList(),
                    AlbumId = song.AlbumId
                };
            }
        }

        public SongDataModel()
        {
            this.Artists = new HashSet<ArtistDataModel>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public Genre Genre { get; set; }

        public ICollection<ArtistDataModel> Artists { get; set; }

        public int AlbumId { get; set; }

    }
}