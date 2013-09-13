namespace MusicCatalogue.DataMappers
{
    using System;
    using System.Linq;
    using MusicCatalogue.DataTransferObjects;
    using MusicCatalogue.Models;
    using MusicCatalogue.Repositories;

    public static class SongsMapper
    {
        public static SongModel ToSongModel(Song songEntity)
        {
            SongModel songModel = new SongModel();
            songModel.ID = songEntity.ID;
            songModel.Title = songEntity.Title;
            songModel.Year = songEntity.Year;
            songModel.Genre = songEntity.Genre;

            foreach (Album album in songEntity.Albums)
            {
                songModel.Albums.Add(new AlbumDetails()
                {
                    ID = album.ID,
                    Title = album.Title,
                    Year = album.Year,
                    Producer = album.Producer
                });
            }

            foreach (Artist artist in songEntity.Artists)
            {
                songModel.Artists.Add(new ArtistDetails()
                {
                    ID = artist.ID,
                    Name = artist.Name,
                    DateOfBirth = artist.DateOfBirth,
                    Country = artist.Country
                });
            }

            return songModel;
        }

        public static Song ToSongEntity(
            SongModel songModel,
            IRepository<Album> albumsRepository,
            IRepository<Artist> artistsRepository)
        {
            Song song = new Song();
            song.ID = songModel.ID;
            song.Title = songModel.Title;
            song.Year = songModel.Year;
            song.Genre = songModel.Genre;

            foreach (AlbumDetails album in songModel.Albums)
            {
                song.Albums.Add(Extensions.CreateOrLoadAlbum(albumsRepository, album));
            }

            foreach (ArtistDetails artist in songModel.Artists)
            {
                song.Artists.Add(Extensions.CreateOrLoadArtist(artistsRepository, artist));
            }

            return song;
        }
    }
}
