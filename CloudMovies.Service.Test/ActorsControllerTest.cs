using CloudMovies.Database.Models;
using CloudMovies.Database.Repositories;
using CloudMovies.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Net;
using Xunit;

namespace CloudMovies.Service.Test
{
    public class ActorsControllerTest
    {
        private Actor[] _actors;

        public ActorsControllerTest()
        {
            _actors = new Actor[]
            {
                new Actor { FirstName = "John", LastName = "Bohn", Birthday = DateTime.Now.AddYears(-20) },
                new Actor { FirstName = "Rohn", LastName = "Bohn", Birthday = DateTime.Now.AddYears(-21) }
            };
        }

        [Fact]
        public void GetActorMovieTest()
        {
            var repository = new Mock<IActorRepository>();
            repository.Setup(r => r.GetMoviesActors(It.IsAny<int>())).
            Returns(_actors);

            var actorsController = new ActorsController(repository.Object);
            var result = actorsController.Get(It.IsAny<int>()) as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(result.StatusCode);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode.Value);
            Assert.IsType<Actor[]>(result.Value);
            Assert.Equal(_actors.Length, ((Actor[])result.Value).Length);
        }

        [Fact]
        public void AddActorMovieTest()
        {
            Actor actor = new Actor()
            {
                FirstName = "actor"
            };

            var repository = new Mock<IActorRepository>();
            repository.Setup(r => r.AddNewActor(actor));

            var actorsController = new ActorsController(repository.Object);
            actorsController.Post(actor);

            repository.Verify(r => r.AddNewActor(actor));
        }
    }
}
