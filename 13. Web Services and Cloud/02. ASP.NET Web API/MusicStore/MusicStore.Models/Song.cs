namespace MusicStore.Models
{
    using System;
    using System.Collections.Generic;

    public class Song
    {
        private ICollection<Artist> artists;

        public Song()
        {
            this.artists = new HashSet<Artist>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public Genre Genre { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}