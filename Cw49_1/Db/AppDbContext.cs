using Cw49_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Cw49_1.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MovieEntity> Movies => Set<MovieEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieEntity>().HasData(
                new MovieEntity { Id = 1, Name = "Inception" },
                new MovieEntity { Id = 2, Name = "The Dark Knight" },
                new MovieEntity { Id = 3, Name = "Interstellar" },
                new MovieEntity { Id = 4, Name = "Matrix" },
                new MovieEntity { Id = 5, Name = "Fight Club" }
            );
        }
    }
}