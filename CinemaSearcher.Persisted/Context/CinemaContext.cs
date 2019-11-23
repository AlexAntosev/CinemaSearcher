using CinemaSearcher.Persisted.Configurations;
using CinemaSearcher.Persisted.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaSearcher.Persisted.Context
{
    public sealed class CinemaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public CinemaContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
        }
    }
}
