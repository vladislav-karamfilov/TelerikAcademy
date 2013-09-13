namespace MusicCatalogue.Client
{
    using MusicCatalogue.DataTransferObjects;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class SongsDataClient
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string ControllerUrl = "api/songs";

        private static readonly MediaTypeWithQualityHeaderValue JsonMediaType =
            new MediaTypeWithQualityHeaderValue(JsonContentType);
        private static readonly MediaTypeWithQualityHeaderValue XmlMediaType =
            new MediaTypeWithQualityHeaderValue(XmlContentType);

        private HttpClient client;

        public SongsDataClient(HttpClient client)
        {
            if (!client.DefaultRequestHeaders.Accept.Contains(JsonMediaType) &&
                !client.DefaultRequestHeaders.Accept.Contains(XmlMediaType))
            {
                throw new ArgumentOutOfRangeException(
                    "Uknown accept content type of client. Only JSON and XML are supported.");
            }

            this.client = client;
        }

        public void AddSong(
            string title,
            int year,
            string genre,
            ICollection<ArtistDetails> artists,
            ICollection<AlbumDetails> albums)
        {
            SongModel newSong = new SongModel()
            {
                Title = title,
                Year = year,
                Genre = genre,
                Albums = albums,
                Artists = artists
            };

            HttpResponseMessage response = null;
            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PostAsJsonAsync<SongModel>(ControllerUrl, newSong).Result;
            }
            else
            {
                response = this.client.PostAsXmlAsync<SongModel>(ControllerUrl, newSong).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public IEnumerable<SongModel> GetSongs()
        {
            var response = this.client.GetAsync(ControllerUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<SongModel>>().Result;
                return songs;
            }

            throw new HttpRequestException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
        }

        public SongModel GetSong(int id)
        {
            var response = this.client.GetAsync(ControllerUrl + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<SongModel>().Result;
                return song;
            }

            throw new HttpRequestException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
        }

        public bool DeleteSong(int id)
        {
            var response = this.client.DeleteAsync(ControllerUrl + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public void UpdateSong(
            int id,
            string title,
            int year,
            string genre,
            ICollection<ArtistDetails> artists,
            ICollection<AlbumDetails> albums)
        {
            SongModel newSong = new SongModel()
            {
                ID = id,
                Title = title,
                Year = year,
                Genre = genre,
                Albums = albums,
                Artists = artists
            };

            HttpResponseMessage response = null;
            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PutAsJsonAsync<SongModel>(ControllerUrl + "/" + id, newSong).Result;
            }
            else
            {
                response = this.client.PutAsXmlAsync<SongModel>(ControllerUrl + "/" + id, newSong).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
            }
        }
    }
}
