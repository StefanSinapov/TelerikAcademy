namespace MusicStore.Models
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Build.Framework;

    public class Artist
    {
        private ICollection<Song> songs;
        private ICollection<Album> albums; 

        public Artist()
        {
            this.songs = new HashSet<Song>();
            this.albums = new HashSet<Album>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string County { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }
            set { this.songs = value; }
        }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}