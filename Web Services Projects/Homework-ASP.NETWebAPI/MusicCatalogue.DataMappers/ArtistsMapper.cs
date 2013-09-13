namespace MusicCatalogue.DataMappers
{
    using System;
    using System.Linq;
    using MusicCatalogue.DataTransferObjects;
    using MusicCatalogue.Models;
    using MusicCatalogue.Repositories;

    public static class ArtistsMapper
    {
        public static ArtistModel ToArtistModel(Artist artistEntity)
        {
            ArtistModel artistModel = new ArtistModel();
            artistModel.ID = artistEntity.ID;
            artistModel.Name = artistEntity.Name;
            artistModel.Country = artistEntity.Country;
            artistModel.DateOfBirth = artistEntity.DateOfBirth;

            foreach (Song song in artistEntity.Songs)
            {
                artistModel.Songs.Add(new SongDetails()
                {
                    ID = song.ID,
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre
                });
            }

            foreach (Album album in artistEntity.Albums)
            {
                artistModel.Albums.Add(new AlbumDetails()
                {
                    ID = album.ID,
                    Title = album.Title,
                    Producer = album.Producer,
                    Year = album.Year
                });
            }

            return artistModel;
        }

        public static Artist ToArtistEntity(
            ArtistModel artistModel,
            IRepository<Album> albumsRepository,
            IRepository<Song> songsRepository)
        {
            Artist artist = new Artist();
            artist.ID = artistModel.ID;
            artist.Name = artistModel.Name;
            artist.DateOfBirth = artistModel.DateOfBirth;
            artist.Country = artistModel.Country;

            foreach (SongDetails song in artistModel.Songs)
            {
                artist.Songs.Add(Extensions.CreateOrLoadSong(songsRepository, song));
            }

            foreach (AlbumDetails album in artistModel.Albums)
            {
                artist.Albums.Add(Extensions.CreateOrLoadAlbum(albumsRepository, album));
            }

            return artist;
        }
    }
}
