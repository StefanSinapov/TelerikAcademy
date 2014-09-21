namespace MusicStore.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public class AlbumDataModel
    {
        public AlbumDataModel()
        {
            this.Songs = new HashSet<SongDataModel>();
            this.Artists = new HashSet<ArtistDataModel>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Producer { get; set; }

        public ICollection<SongDataModel> Songs { get; set; }

        public ICollection<ArtistDataModel> Artists { get; set; }

        public static Expression<Func<Album, AlbumDataModel>> FromEntityToModel
        {
            get
            {
                return album => new AlbumDataModel
                {
                    Id = album.Id,
                    Title = album.Title,
                    Year = album.Year,
                    Producer = album.Producer,
                    Artists = album.Artists.AsQueryable().Select(ArtistDataModel.FromEntityToModel).ToList(),
                    Songs = album.Songs.AsQueryable().Select(SongDataModel.FromEntityToModel).ToList()
                };
            }
        }
    }
}