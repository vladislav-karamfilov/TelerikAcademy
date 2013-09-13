namespace MusicCatalogue.Data
{
    using System.Data.Entity;
    using MusicCatalogue.Models;

    public class MusicCatalogueContext : DbContext
    {
        public MusicCatalogueContext()
            : base("MusicCatalogueDB")
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }
    }
}
