namespace MusicCatalogue.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Song
    {
        private ICollection<Artist> artists;
        private ICollection<Album> albums;

        public Song()
        {
            this.albums = new HashSet<Album>();
            this.artists = new HashSet<Artist>();
        }

        [Key, Column("SongID")]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public int Year { get; set; }

        [Required]
        public string Genre { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }

            set { this.albums = value; }
        }

        public virtual ICollection<Artist> Artists
        {
            get { return this.artists; }

            set { this.artists = value; }
        }
    }
}
