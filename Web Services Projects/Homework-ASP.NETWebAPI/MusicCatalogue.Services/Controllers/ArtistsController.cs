namespace MusicCatalogue.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MusicCatalogue.Models;
    using MusicCatalogue.DataMappers;
    using MusicCatalogue.DataTransferObjects;
    using MusicCatalogue.Repositories;

    public class ArtistsController : ApiController
    {
        private IRepository<Album> albumsRepository;
        private IRepository<Artist> artistsRepository;
        private IRepository<Song> songsRepository;

        public ArtistsController(
            IRepository<Album> albumsRepository,
            IRepository<Artist> artistsRepository,
            IRepository<Song> songsRepository)
        {
            this.albumsRepository = albumsRepository;
            this.artistsRepository = artistsRepository;
            this.songsRepository = songsRepository;
        }

        [HttpGet]
        public IEnumerable<ArtistModel> GetArtists()
        {
            IList<ArtistModel> artists = new List<ArtistModel>();
            foreach (Artist artist in this.artistsRepository.GetAll().ToList())
            {
                artists.Add(ArtistsMapper.ToArtistModel(artist));
            }

            return artists;
        }

        [HttpGet]
        public ArtistModel GetArtist(int id)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            Artist artist = this.artistsRepository.Get(id);
            if (artist == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            ArtistModel artistModel = ArtistsMapper.ToArtistModel(artist);
            return artistModel;
        }

        [HttpPost]
        public HttpResponseMessage AddArtist(ArtistModel artist)
        {
            Artist newArtist = null;
            try
            {
                newArtist = ArtistsMapper.ToArtistEntity(artist, albumsRepository, songsRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid artist model provided!");
            }

            artistsRepository.Add(newArtist);
            artist.ID = newArtist.ID;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, artist);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = artist.ID }));
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateArtist(int id, [FromBody]ArtistModel artist)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            if (id != artist.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Artist updatedArtist = null;
            try
            {
                updatedArtist = ArtistsMapper.ToArtistEntity(artist, albumsRepository, songsRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid artist model provided!");
            }

            this.artistsRepository.Update(id, updatedArtist);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteArtist(int id)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            bool deleted = this.artistsRepository.Delete(id);
            if (!deleted)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
