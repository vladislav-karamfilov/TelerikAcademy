namespace MusicCatalogue.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using MusicCatalogue.DataTransferObjects;
    using MusicCatalogue.DataMappers;
    using MusicCatalogue.Models;
    using MusicCatalogue.Repositories;

    public class AlbumsController : ApiController
    {
        private IRepository<Album> albumsRepository;
        private IRepository<Artist> artistsRepository;
        private IRepository<Song> songsRepository;

        public AlbumsController(
            IRepository<Album> albumsRepository,
            IRepository<Artist> artistsRepository,
            IRepository<Song> songsRepository)
        {
            this.albumsRepository = albumsRepository;
            this.artistsRepository = artistsRepository;
            this.songsRepository = songsRepository;
        }

        [HttpGet]
        public IEnumerable<AlbumModel> GetAlbums()
        {
            IList<AlbumModel> albums = new List<AlbumModel>();
            foreach (Album album in this.albumsRepository.GetAll().ToList())
            {
                albums.Add(AlbumsMapper.ToAlbumModel(album));
            }

            return albums;
        }

        [HttpGet]
        public AlbumModel GetAlbum(int id)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            Album album = this.albumsRepository.Get(id);
            if (album == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            AlbumModel albumModel = AlbumsMapper.ToAlbumModel(album);
            return albumModel;
        }

        [HttpPost]
        public HttpResponseMessage AddAlbum(AlbumModel album)
        {
            Album newAlbum = null;
            try
            {
                newAlbum = AlbumsMapper.ToAlbumEntity(album, artistsRepository, songsRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid album model provided!");
            }

            albumsRepository.Add(newAlbum);
            album.ID = newAlbum.ID;
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, album);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = album.ID }));
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateAlbum(int id, AlbumModel album)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            if (id != album.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Album updatedAlbum = null;
            try
            {
                updatedAlbum = AlbumsMapper.ToAlbumEntity(album, artistsRepository, songsRepository);
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid album model provided!");
            }

            this.albumsRepository.Update(id, updatedAlbum);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteAlbum(int id)
        {
            if (id <= 0)
            {
                HttpResponseMessage errorResponse = Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, "Provided id must be a positive integer!");
                throw new HttpResponseException(errorResponse);
            }

            bool deleted = this.albumsRepository.Delete(id);
            if (!deleted)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
