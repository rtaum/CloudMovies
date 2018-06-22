using CloudMovies.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace CloudMovies.Service.Validation
{
    public class MovieValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var item in context.ActionArguments)
            {
                var movie = item.Value as Movie;
                if (movie == null)
                {
                    continue;
                }

                if (movie.Year > DateTime.Now.Year)
                {
                    context.ModelState.AddModelError("MovieValidationError",
                        $"{nameof(movie.Year)} cannot be greater than {DateTime.Now.Year}.");

                }

                if (movie.MovieActors == null ||
                    movie.MovieActors.Count() == 0)
                {
                    context.ModelState.AddModelError("MovieValidationError",
                        $"{nameof(movie.MovieActors)} list cannot be empty.");
                }

                break;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
