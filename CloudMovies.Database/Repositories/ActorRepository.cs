using CloudMovies.Context.Databases;
using CloudMovies.Database.Models;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System.Collections.Generic;
using System.Linq;

namespace CloudMovies.Database.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private CloudMoviesContext _cloudMoviesContext;

        public ActorRepository(CloudMoviesContext cloudMoviesContext)
        {
            _cloudMoviesContext = cloudMoviesContext;
        }

        public Actor AddNewActor(Actor actor)
        {
            _cloudMoviesContext.Actors.Add(actor);
            actor.Id = _cloudMoviesContext.SaveChanges();
            return actor;
        }

        public IEnumerable<Actor> GetMoviesActors(int movieId)
        {
            return _cloudMoviesContext.
                MovieActor.
                Where(ma => ma.MovieId == movieId).
                Select(a => a.Actor).
                ToList();
        }
    }
}
