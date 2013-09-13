namespace MusicCatalogue.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MusicCatalogue.DataTransferObjects;
    using MusicCatalogue.Models;
    using MusicCatalogue.Repositories;
    using MusicCatalogue.DataMappers;

    public class SongsController : ApiController
    {
        private IRepository<Album> albumsRepository;
        private IRepository<Artist> artistsRepository;
        private IRepository<Song> songsRepository;

        public SongsController(
            IRepository<Album> albumsRepository,
            IRepository<Artist> artistsRepository,
            IRepository<Song> songsRepository)
        {
            this.albumsRepository = albumsRepository;
            this.artistsRepository = artistsRepository;
            this.songsRepository = songsRepository;
        }

        [HttpGet]
        public IEnumerable<SongModel> GetSongs()
        {
            IList<SongModel> songs = new List<SongModel>();
            foreach (Song song in this.songsRepository.GetAll().ToList())
            {
                songs.Add(SongsMapper.ToSongModel(song));
            }

            return songs;
        }

        [HttpGet]
        public SongModel GetSong(int id)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            Song song = this.songsRepository.Get(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            SongModel songModel = SongsMapper.ToSongModel(song);
            return songModel;
        }

        [HttpPost]
        public HttpResponseMessage AddSong([FromBody]SongModel song)
        {
            Song newSong = null;
            try
            {
                newSong = SongsMapper.ToSongEntity(song, albumsRepository, artistsRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid song model provided!");
            }

            songsRepository.Add(newSong);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
            song.ID = newSong.ID;
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.ID }));
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateSong(int id, SongModel song)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            if (id != song.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Song updatedSong = null;
            try
            {
                updatedSong = SongsMapper.ToSongEntity(song, albumsRepository, artistsRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid song model provided!");
            }

            this.songsRepository.Update(id, updatedSong);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteSong(int id)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            bool deleted = this.songsRepository.Delete(id);
            if (!deleted)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
