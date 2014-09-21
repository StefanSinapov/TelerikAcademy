namespace MusicStore.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Models;

    public class ArtistDataModel
    {
        public static Expression<Func<Artist, ArtistDataModel>> FromEntityToModel
        {
            get
            {
                return a => new ArtistDataModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    County = a.County,
                    Albums = a.Albums.AsQueryable().Select(AlbumDataModel.FromEntityToModel).ToList(),
                    Songs = a.Songs.AsQueryable().Select(SongDataModel.FromEntityToModel).ToList(),
                    DateOfBirth = a.DateOfBirth
                };
            }
        }

        public ArtistDataModel()
        {
            this.Songs = new HashSet<SongDataModel>();
            this.Albums = new HashSet<AlbumDataModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string County { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public ICollection<SongDataModel> Songs { get; set; }

        public ICollection<AlbumDataModel> Albums { get; set; }
    }
}