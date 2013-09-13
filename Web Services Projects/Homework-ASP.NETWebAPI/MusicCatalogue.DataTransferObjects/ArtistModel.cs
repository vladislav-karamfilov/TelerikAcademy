namespace MusicCatalogue.DataTransferObjects
{
    using System.Collections.Generic;

    public class ArtistModel : ArtistDetails
    {
        public ArtistModel()
        {
            this.Songs = new HashSet<SongDetails>();
            this.Albums = new HashSet<AlbumDetails>();
        }

        public ICollection<SongDetails> Songs { get; set; }

        public ICollection<AlbumDetails> Albums { get; set; }
    }
}
