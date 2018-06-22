using CloudMovies.Context.Databases;
using CloudMovies.Database.Models;
using System.Collections.Generic;
using System.Linq;

namespace CloudMovies.Database.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private CloudMoviesContext _cloudMoviesContext;

        public MovieRepository(CloudMoviesContext cloudMoviesContext)
        {
            _cloudMoviesContext = cloudMoviesContext;
        }

        public void AddActorToMovie(int movieid, int actorid)
        {
            var movie = _cloudMoviesContext.
                MovieActor.
                Add(new MovieActor()
                {
                    MovieId = movieid,
                    ActorId = actorid
                });
            _cloudMoviesContext.SaveChanges();
        }

        public int AddNewMovie(Movie movie)
        {
            _cloudMoviesContext.
                Movies.
                Add(movie);
            return _cloudMoviesContext.SaveChanges();
        }

        public void DeleteMovie(int movieId)
        {
            var movie = new Movie() { Id = movieId };
            _cloudMoviesContext.
                Movies.
                Remove(movie);
            _cloudMoviesContext.SaveChanges();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _cloudMoviesContext.Movies.ToList();
        }

        public IEnumerable<Movie> GetAllMoviesByActor(int actorId)
        {
            return _cloudMoviesContext.
                MovieActor.
                Where(ma => ma.ActorId == actorId).
                Select(a => a.Movie).
                ToList();
        }

        public IEnumerable<Movie> GetAllMoviesByProductionYear(int year)
        {
            return _cloudMoviesContext.
                Movies.
                Where(m => m.Year == year).
                ToList();
        }

        public void UpdateMovie(Movie movie)
        {
            _cloudMoviesContext.
                Movies.
                Update(movie);
            _cloudMoviesContext.SaveChanges();
        }
    }
}
