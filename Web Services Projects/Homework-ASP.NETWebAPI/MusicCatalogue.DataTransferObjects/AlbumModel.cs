namespace MusicCatalogue.DataTransferObjects
{
    using System.Collections.Generic;

    public class AlbumModel : AlbumDetails
    {
        public AlbumModel()
        {
            this.Songs = new HashSet<SongDetails>();
            this.Artists = new HashSet<ArtistDetails>();
        }

        public ICollection<SongDetails> Songs { get; set; }

        public ICollection<ArtistDetails> Artists { get; set; }
    }
}
