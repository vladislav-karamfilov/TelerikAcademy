namespace MusicCatalogue.DataTransferObjects
{
    using System.Collections.Generic;

    public class SongModel : SongDetails
    {
        public SongModel()
        {
            this.Albums = new HashSet<AlbumDetails>();
            this.Artists = new HashSet<ArtistDetails>();
        }

        public ICollection<ArtistDetails> Artists { get; set; }

        public ICollection<AlbumDetails> Albums { get; set; }
    }
}
