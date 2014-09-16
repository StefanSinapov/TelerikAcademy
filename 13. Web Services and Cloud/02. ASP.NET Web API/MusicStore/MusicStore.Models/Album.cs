namespace MusicStore.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Build.Framework;

    public class Album
    {
        private ICollection<Song> songs;
        private ICollection<Artist> artists; 

        public Album()
        {
            this.songs = new HashSet<Song>();
            this.artists = new HashSet<Artist>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime? Year { get; set; }

        public string Producer { get; set; }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }
            set { this.artists = value; }
        }
    }
}