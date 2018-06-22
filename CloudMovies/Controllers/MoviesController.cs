using CloudMovies.Database.Models;
using CloudMovies.Database.Repositories;
using CloudMovies.Service.Filters;
using CloudMovies.Service.Validation;
using Microsoft.AspNetCore.Mvc;

namespace CloudMovies.Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ExceptionHandling]
    public class MoviesController : Controller
    {
        private IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_movieRepository.GetAllMovies());
        }

        [HttpGet("year/{year}")]
        public IActionResult GetByYear([FromRoute]int year)
        {
            return Ok(_movieRepository.GetAllMoviesByProductionYear(year));
        }

        [HttpGet("actor/{actorId}")]
        public IActionResult GetByActor([FromRoute]int actorId)
        {
            return Ok(_movieRepository.GetAllMoviesByActor(actorId));
        }

        [HttpPost]
        [MovieValidation]
        public void Post([FromBody]Movie movie)
        {
            _movieRepository.AddNewMovie(movie);
        }

        [HttpPut]
        [MovieValidation]
        public void Put([FromBody]Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }

        [HttpPut("actors/{actorId}")]
        public void Put([FromRoute] int actorId, [FromBody] Movie movie)
        {
            _movieRepository.AddActorToMovie(movie.Id, actorId);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _movieRepository.DeleteMovie(id);
        }
    }
}
