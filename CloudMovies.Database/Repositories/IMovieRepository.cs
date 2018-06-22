using CloudMovies.Database.Models;
using System.Collections.Generic;

namespace CloudMovies.Database.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();

        IEnumerable<Movie> GetAllMoviesByProductionYear(int year);

        IEnumerable<Movie> GetAllMoviesByActor(int actorId);

        int AddNewMovie(Movie movie);

        void AddActorToMovie(int movieid, int actorid);

        void UpdateMovie(Movie movie);

        void DeleteMovie(int movieId);
    }
}
