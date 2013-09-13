namespace MusicCatalogue.Services.DependencyResolvers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Http.Dependencies;
    using MusicCatalogue.Data;
    using MusicCatalogue.Models;
    using MusicCatalogue.Repositories;
    using MusicCatalogue.Services.Controllers;

    public class DbDependencyResolver : IDependencyResolver
    {
        private static DbContext context;
        private static IRepository<Artist> artistsRepository;
        private static IRepository<Album> albumsRepository;
        private static IRepository<Song> songsRepository;

        static DbDependencyResolver()
        {
            context = new MusicCatalogueContext();
            artistsRepository = new DbRepository<Artist>(context);
            albumsRepository = new DbRepository<Album>(context);
            songsRepository = new DbRepository<Song>(context);
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(AlbumsController))
            {
                return new AlbumsController(albumsRepository, artistsRepository, songsRepository);
            }
            else if (serviceType == typeof(ArtistsController))
            {
                return new ArtistsController(albumsRepository, artistsRepository, songsRepository);
            }
            else if (serviceType == typeof(SongsController))
            {
                return new SongsController(albumsRepository, artistsRepository, songsRepository);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(System.Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose() { }
    }
}