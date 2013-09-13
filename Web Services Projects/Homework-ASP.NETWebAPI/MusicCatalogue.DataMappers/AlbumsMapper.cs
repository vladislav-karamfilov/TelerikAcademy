namespace MusicCatalogue.DataMappers
{
    using System;
    using MusicCatalogue.DataTransferObjects;
    using MusicCatalogue.Models;
    using MusicCatalogue.Repositories;

    public static class AlbumsMapper
    {
        public static AlbumModel ToAlbumModel(Album albumEntity)
        {
            AlbumModel albumModel = new AlbumModel();
            albumModel.ID = albumEntity.ID;
            albumModel.Title = albumEntity.Title;
            albumModel.Year = albumEntity.Year;
            albumModel.Producer = albumEntity.Producer;

            foreach (Song song in albumEntity.Songs)
            {
                albumModel.Songs.Add(new SongDetails()
                {
                    ID = song.ID,
                    Title = song.Title,
                    Year = song.Year,
                    Genre = song.Genre
                });
            }

            foreach (Artist artist in albumEntity.Artists)
            {
                albumModel.Artists.Add(new ArtistDetails()
                {
                    ID = artist.ID,
                    Name = artist.Name,
                    DateOfBirth = artist.DateOfBirth,
                    Country = artist.Country
                });
            }

            return albumModel;
        }

        public static Album ToAlbumEntity(
            AlbumModel albumModel,
            IRepository<Artist> artistsRepository,
            IRepository<Song> songsRepository)
        {
            Album album = new Album();
            album.ID = albumModel.ID;
            album.Title = albumModel.Title;
            album.Year = albumModel.Year;
            album.Producer = albumModel.Producer;

            foreach (SongDetails song in albumModel.Songs)
            {
                album.Songs.Add(Extensions.CreateOrLoadSong(songsRepository, song));
            }

            foreach (ArtistDetails artist in albumModel.Artists)
            {
                album.Artists.Add(Extensions.CreateOrLoadArtist(artistsRepository, artist));
            }

            return album;
        }
    }
}
