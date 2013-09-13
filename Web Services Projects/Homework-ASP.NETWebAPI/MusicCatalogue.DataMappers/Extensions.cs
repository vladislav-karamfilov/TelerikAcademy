namespace MusicCatalogue.DataMappers
{
    using MusicCatalogue.DataTransferObjects;
    using MusicCatalogue.Models;
    using MusicCatalogue.Repositories;

    internal static class Extensions
    {
        public static Artist CreateOrLoadArtist(IRepository<Artist> artists, ArtistDetails artistDetails)
        {
            Artist artist = artists.Get(artistDetails.ID);
            if (artist != null)
            {
                return artist;
            }

            Artist newArtist = new Artist()
            {
                Name = artistDetails.Name,
                Country = artistDetails.Country,
                DateOfBirth = artistDetails.DateOfBirth
            };

            artists.Add(newArtist);

            return newArtist;
        }

        public static Album CreateOrLoadAlbum(IRepository<Album> albums, AlbumDetails albumDetails)
        {
            Album album = albums.Get(albumDetails.ID);
            if (album != null)
            {
                return album;
            }

            Album newAlbum = new Album()
            {
                Title = albumDetails.Title,
                Producer = albumDetails.Producer,
                Year = albumDetails.Year
            };

            albums.Add(newAlbum);

            return newAlbum;
        }

        public static Song CreateOrLoadSong(IRepository<Song> songs, SongDetails songDetails)
        {
            Song song = songs.Get(songDetails.ID);
            if (song != null)
            {
                return song;
            }

            Song newSong = new Song()
            {
                Title = songDetails.Title,
                Genre = songDetails.Genre,
                Year = songDetails.Year
            };

            songs.Add(newSong);

            return newSong;
        }
    }
}
