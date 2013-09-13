namespace MusicCatalogue.Client
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Collections.Generic;
    using MusicCatalogue.DataTransferObjects;

    internal class ArtistsDataClient
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string ControllerUrl = "api/artists";

        private static readonly MediaTypeWithQualityHeaderValue JsonMediaType =
            new MediaTypeWithQualityHeaderValue(JsonContentType);
        private static readonly MediaTypeWithQualityHeaderValue XmlMediaType =
            new MediaTypeWithQualityHeaderValue(XmlContentType);

        private HttpClient client;

        public ArtistsDataClient(HttpClient client)
        {
            if (!client.DefaultRequestHeaders.Accept.Contains(JsonMediaType) &&
                !client.DefaultRequestHeaders.Accept.Contains(XmlMediaType))
            {
                throw new ArgumentOutOfRangeException(
                    "Uknown accept content type of client. Only JSON and XML are supported.");
            }

            this.client = client;
        }

        public void AddArtist(
            string name,
            string country,
            DateTime dateOfBirth,
            ICollection<SongDetails> songs,
            ICollection<AlbumDetails> albums)
        {
            ArtistModel newArtist = new ArtistModel()
            {
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth,
                Songs = songs,
                Albums = albums
            };

            HttpResponseMessage response = null;
            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PostAsJsonAsync<ArtistModel>(ControllerUrl, newArtist).Result;
            }
            else
            {
                response = this.client.PostAsXmlAsync<ArtistModel>(ControllerUrl, newArtist).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
            }
        }

        public IEnumerable<ArtistModel> GetArtists()
        {
            var response = this.client.GetAsync(ControllerUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModel>>().Result;
                return artists;
            }

            throw new HttpRequestException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
        }

        public ArtistModel GetArtist(int id)
        {
            var response = this.client.GetAsync(ControllerUrl + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<ArtistModel>().Result;
                return artist;
            }

            throw new HttpRequestException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
        }

        public bool DeleteArtist(int id)
        {
            var response = this.client.DeleteAsync(ControllerUrl + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public void UpdateArtist(
            int id,
            string name,
            string country,
            DateTime dateOfBirth,
            ICollection<SongDetails> songs,
            ICollection<AlbumDetails> albums)
        {
            ArtistModel newArtist = new ArtistModel()
            {
                ID = id,
                Name = name,
                Country = country,
                DateOfBirth = dateOfBirth,
                Songs = songs,
                Albums = albums
            };

            HttpResponseMessage response = null;
            if (this.client.DefaultRequestHeaders.Accept.Contains(JsonMediaType))
            {
                response = this.client.PutAsJsonAsync<ArtistModel>(ControllerUrl + "/" + id, newArtist).Result;
            }
            else
            {
                response = this.client.PutAsXmlAsync<ArtistModel>(ControllerUrl + "/" + id, newArtist).Result;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("{0} ({1})",
                    (int)response.StatusCode, response.ReasonPhrase));
            }
        }
    }
}
