namespace MusicCatalogue.Client
{
    using MusicCatalogue.DataTransferObjects;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Linq;

    public class MusicCatalogueUI
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string ServerUrl = "http://localhost:38573/";

        internal static void Main()
        {
            string decorationLine = new string('-', Console.WindowWidth);
            Console.Write(decorationLine);
            Console.WriteLine("***Performing CRUD operations for a music catalogue through services***");
            Console.Write(decorationLine);

            HttpClient jsonClient = new HttpClient { BaseAddress = new Uri(ServerUrl) };
            jsonClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(JsonContentType));

            HttpClient xmlClient = new HttpClient() { BaseAddress = new Uri(ServerUrl) };
            xmlClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(XmlContentType));

            ArtistsDataClient artistsJsonDataClient = new ArtistsDataClient(jsonClient);
            ArtistsDataClient artistsXmlDataClient = new ArtistsDataClient(xmlClient);

            #region CRUD operations performed
            // Create operation
            AddArtists(artistsJsonDataClient, artistsXmlDataClient);

            // Get artists -> read operation
            ArtistModel artistWithId2 = artistsJsonDataClient.GetArtist(2);
            ArtistModel artistWithId3 = artistsXmlDataClient.GetArtist(3);

            // Convert to details to use in other methods
            ArtistDetails artistDetailsId2 = ConvertToArtistDetails(artistWithId2);
            ArtistDetails artistDetailsId3 = ConvertToArtistDetails(artistWithId3);

            IEnumerable<ArtistModel> allArtists = artistsJsonDataClient.GetArtists();

            // Convert to details to use in other methods
            IList<ArtistDetails> allArtistsDetails = new List<ArtistDetails>(allArtists.Count());
            foreach (ArtistModel artistModel in allArtists)
            {
                allArtistsDetails.Add(ConvertToArtistDetails(artistModel));
            }

            SongsDataClient songsJsonDao = new SongsDataClient(jsonClient);
            SongsDataClient songsXmlDao = new SongsDataClient(xmlClient);

            // Create operation
            AddSongs(artistDetailsId2, artistDetailsId3, songsJsonDao, songsXmlDao);

            // GetSongs -> read operation
            SongModel songWithId1 = songsJsonDao.GetSong(1);
            SongModel songWithId3 = songsXmlDao.GetSong(3);

            // Convert to details to use in other methods
            SongDetails songDetailsId1 = ConvertToSongDetails(songWithId1);
            SongDetails songDetailsId3 = ConvertToSongDetails(songWithId3);

            IEnumerable<SongModel> allSongs = songsXmlDao.GetSongs();

            // Convert to details to use in other methods
            IList<SongDetails> allSongsDetails = new List<SongDetails>(allSongs.Count());
            foreach (SongModel songModel in allSongs)
            {
                allSongsDetails.Add(ConvertToSongDetails(songModel));
            }

            AlbumsDataClient albumsJsonDao = new AlbumsDataClient(jsonClient);
            AlbumsDataClient albumsXmlDao = new AlbumsDataClient(xmlClient);

            // Create operation
            albumsJsonDao.AddAlbum("Album 1", 2012, "Producer 1",
                allSongsDetails, new List<ArtistDetails>(allArtistsDetails));
            albumsXmlDao.AddAlbum("Album 2", 2013, "Producer 2",
               new List<SongDetails>() { songDetailsId1, songDetailsId3 },
               new List<ArtistDetails>() { artistDetailsId2, artistDetailsId3 });

            // Get operation
            IEnumerable<AlbumModel> allAlbums = albumsJsonDao.GetAlbums();

            // Convert to details to use in other methods
            IList<AlbumDetails> allAlbumsDetails = new List<AlbumDetails>(allAlbums.Count());
            foreach (AlbumModel albumModel in allAlbums)
            {
                allAlbumsDetails.Add(ConvertToAlbumDetails(albumModel));
            }

            // Update operations 
            artistsJsonDataClient.UpdateArtist(
                1, "Artist 10", "England", new DateTime(1968, 2, 22), new List<SongDetails>(), new List<AlbumDetails>());
            artistsXmlDataClient.UpdateArtist(
                4, "Artist 40", "Denmark", new DateTime(1968, 2, 22), new List<SongDetails>(), new List<AlbumDetails>());

            songsJsonDao.UpdateSong(
                2, "Song 20", 2011, "Metal", new List<ArtistDetails>(allArtistsDetails), new List<AlbumDetails>(allAlbumsDetails));

            albumsXmlDao.UpdateAlbum(
                1, "Album 10", 2013, "Producer 1", new List<SongDetails>(allSongsDetails), new List<ArtistDetails>(allArtistsDetails));

            // Remove operations
            artistsJsonDataClient.DeleteArtist(6);
            albumsXmlDao.DeleteAlbum(2);
            songsJsonDao.DeleteSong(5);
            Console.WriteLine("All operations performed successfully!");
            #endregion
        }

        private static void AddSongs(
            ArtistDetails artistWithId2,
            ArtistDetails artistWithId3,
            SongsDataClient songsJsonDataClient,
            SongsDataClient songsXmlDataClient)
        {
            songsJsonDataClient.AddSong("Song 1", 2009, "Hip-Hop",
                new List<ArtistDetails>() { artistWithId2, artistWithId3 }, new List<AlbumDetails>());
            songsJsonDataClient.AddSong("Song 2", 2011, "House",
                new List<ArtistDetails>() { artistWithId3 }, new List<AlbumDetails>());
            songsXmlDataClient.AddSong("Song 3", 2009, "Trance",
                new List<ArtistDetails>() { artistWithId2 }, new List<AlbumDetails>());
            songsXmlDataClient.AddSong("Song 4", 2009, "Pop",
                new List<ArtistDetails>() { artistWithId3 }, new List<AlbumDetails>());
            songsXmlDataClient.AddSong("Song 5", 2009, "Rap",
                new List<ArtistDetails>() { artistWithId2 }, new List<AlbumDetails>());
        }

        private static void AddArtists(ArtistsDataClient aritstsJsonDataClient, ArtistsDataClient artistsXmlDataClient)
        {
            // Add in JSON format
            aritstsJsonDataClient.AddArtist(
                "Artist 1", "Bulgaria", new DateTime(1988, 2, 2), new List<SongDetails>(), new List<AlbumDetails>());
            aritstsJsonDataClient.AddArtist(
                "Artist 2", "Bulgaria", new DateTime(1968, 2, 22), new List<SongDetails>(), new List<AlbumDetails>());
            aritstsJsonDataClient.AddArtist(
                "Artist 5", "Bulgaria", new DateTime(1979, 2, 22), new List<SongDetails>(), new List<AlbumDetails>());

            // Add in XML format
            artistsXmlDataClient.AddArtist(
                "Artist 3", "Bulgaria", new DateTime(1981, 2, 12), new List<SongDetails>(), new List<AlbumDetails>());
            artistsXmlDataClient.AddArtist(
                "Artist 4", "Bulgaria", new DateTime(1978, 12, 22), new List<SongDetails>(), new List<AlbumDetails>());
            artistsXmlDataClient.AddArtist(
                "Artist 6", "Bulgaria", new DateTime(1968, 2, 22), new List<SongDetails>(), new List<AlbumDetails>());
        }

        private static ArtistDetails ConvertToArtistDetails(ArtistModel artistModel)
        {
            ArtistDetails artistDetails = new ArtistDetails()
            {
                ID = artistModel.ID,
                Name = artistModel.Name,
                DateOfBirth = artistModel.DateOfBirth,
                Country = artistModel.Country
            };

            return artistDetails;
        }

        private static AlbumDetails ConvertToAlbumDetails(AlbumModel albumModel)
        {
            AlbumDetails albumDetails = new AlbumDetails()
            {
                ID = albumModel.ID,
                Title = albumModel.Title,
                Producer = albumModel.Producer,
                Year = albumModel.Year
            };

            return albumDetails;
        }

        private static SongDetails ConvertToSongDetails(SongModel songModel)
        {
            SongDetails songDetails = new SongDetails()
            {
                ID = songModel.ID,
                Title = songModel.Title,
                Genre = songModel.Genre,
                Year = songModel.Year
            };

            return songDetails;
        }
    }
}
