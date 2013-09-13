namespace MusicCatalogue.Client
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
     using System.Collections.Generic;
    using MusicCatalogue.DataTransferObjects;

    internal class AlbumsDataClient
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string ControllerUrl = "api/albums";

        private static readonly MediaTypeWithQualityHeaderValue JsonMediaType =
            new MediaTypeWithQualityHeaderValue(JsonContentType);
        private static readonly MediaTypeWithQualityHeaderValue XmlMediaType =
            new MediaTypeWithQualityHeaderValue(XmlContentType);

        private HttpClient client;

        public AlbumsDataClient(HttpClient client)
        {
            if (!client.DefaultRequestHeaders.Accept.Contains(JsonMediaType) &&
                !client.DefaultRequestHeaders.Accept.Contains(XmlMediaType))
            {
                throw new ArgumentOutOfRangeException(
                    "Uknown accept content type of client. Only JSON and XML are supported.");
            }

            this.client = client;
        }

        public void AddAlbum(
            string title,
            int year,
            string producer,
            ICollection<SongDetails> songs,
            ICollection<ArtistDetails> artists)
        {
            AlbumModel newAlbum = new AlbumModel()
            {
                Title = title,
                Year = year,
                Producer = producer,
                Songs = songs,
                Artists = artists
            };

            HttpResponseMessage response = null;
            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PostAsJsonAsync<AlbumModel>(ControllerUrl, newAlbum).Result;
            }
            else
            {
                response = this.client.PostAsXmlAsync<AlbumModel>(ControllerUrl, newAlbum).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public IEnumerable<AlbumModel> GetAlbums()
        {
            var response = this.client.GetAsync(ControllerUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<AlbumModel>>().Result;
                return albums;
            }

            throw new HttpRequestException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
        }

        public AlbumModel GetAlbum(int id)
        {
            var response = this.client.GetAsync(ControllerUrl + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var album = response.Content.ReadAsAsync<AlbumModel>().Result;
                return album;
            }

            throw new HttpRequestException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
        }

        public bool DeleteAlbum(int id)
        {
            var response = this.client.DeleteAsync(ControllerUrl + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public void UpdateAlbum(
            int id,
            string title,
            int year,
            string producer,
            ICollection<SongDetails> songs,
            ICollection<ArtistDetails> artists)
        {
            AlbumModel newAlbum = new AlbumModel()
            {
                ID = id,
                Title = title,
                Year = year,
                Producer = producer,
                Songs = songs,
                Artists = artists
            };

            HttpResponseMessage response = null;
            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PutAsJsonAsync<AlbumModel>(ControllerUrl + "/" + id, newAlbum).Result;
            }
            else
            {
                response = this.client.PutAsXmlAsync<AlbumModel>(ControllerUrl + "/" + id, newAlbum).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})",
                     (int)response.StatusCode, response.ReasonPhrase));
            }
        }
    }
}
