using CloudMovies.Database.Models;
using System.Collections.Generic;

namespace CloudMovies.Database.Repositories
{
    public interface IActorRepository
    {
        Actor AddNewActor(Actor actor);

        IEnumerable<Actor> GetMoviesActors(int movieId);
    }
}
