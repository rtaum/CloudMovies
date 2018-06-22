using CloudMovies.Database.Models;
using CloudMovies.Database.Repositories;
using CloudMovies.Service.Filters;
using CloudMovies.Service.Validation;
using Microsoft.AspNetCore.Mvc;

namespace CloudMovies.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ExceptionHandling]
    public class ActorsController : Controller
    {
        private IActorRepository _actorsRepository;

        public ActorsController(IActorRepository actorsRepository)
        {
            _actorsRepository = actorsRepository;
        }

        [HttpGet("{movieid}", Name = "Get")]
        public IActionResult Get(int movieid)
        {
            return Ok(_actorsRepository.GetMoviesActors(movieid));
        }
        

        [HttpPost]
        [ActorValidation]
        public void Post([FromBody]Actor actor)
        {
            _actorsRepository.AddNewActor(actor);
        }
    }
}
