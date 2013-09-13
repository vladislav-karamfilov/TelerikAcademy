namespace MusicCatalogue.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Album
    {
        private ICollection<Artist> artists;
        private ICollection<Song> songs;

        public Album()
        {
            this.artists = new HashSet<Artist>();
            this.songs = new HashSet<Song>();
        }

        [Key, Column("AlbumID")]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        [Required]
        public string Producer { get; set; }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }

            set { this.artists = value; }
        }

        public virtual ICollection<Song> Songs
        {
            get { return this.songs; }

            set { this.songs = value; }
        }
    }
}
