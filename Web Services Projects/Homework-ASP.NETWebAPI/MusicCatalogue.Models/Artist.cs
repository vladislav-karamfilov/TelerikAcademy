namespace MusicCatalogue.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Artist
    {
        private ICollection<Album> albums;
        private ICollection<Song> songs;

        public Artist()
        {
            this.albums = new HashSet<Album>();
            this.songs = new HashSet<Song>();
        }

        [Key, Column("ArtistID")]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }

            set { this.albums = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }

            set { this.songs = value; }
        }
    }
}
