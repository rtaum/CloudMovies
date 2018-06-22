using CloudMovies.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudMovies.Context.Databases
{
    public class CloudMoviesContext : DbContext
    {
        public CloudMoviesContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieActor> MovieActor { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Movie>()
                .HasMany(p => p.MovieActors)
                .WithOne(p => p.Movie)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Actor>()
                .HasMany(p => p.ActorMovies)
                .WithOne(p => p.Actor)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            ////PK for the join entity
            //builder.Entity<PersonAddress>()
            //    .HasKey(x => new { x.AddressId, x.PersonId });

            //builder.Entity<PersonAddress>()
            //    .HasOne(p => p.Person)
            //    .WithMany(p => p.Addresses)
            //    .IsRequired();

            //builder.Entity<PersonAddress>()
            //    .HasOne(p => p.Address)
            //    .WithMany(p => p.People)
            //    .IsRequired();
        }
    }
}
