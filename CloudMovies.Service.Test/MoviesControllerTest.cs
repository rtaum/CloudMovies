using CloudMovies.Database.Models;
using CloudMovies.Database.Repositories;
using CloudMovies.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using Xunit;

namespace CloudMovies.Service.Test
{
    public class MoviesControllerTest
    {
        private Movie[] _movies;

        public MoviesControllerTest()
        {
            _movies = new Movie[]
            {
                new Movie { Title = "Jaws", Genre = "Horror", Year = 1975 },
                new Movie { Title = "Alien", Genre = "Horror", Year = 1980 }
            };
        }

        [Fact]
        public void GetAllMoviesTest()
        {
            var repository = MockRepository(r => r.GetAllMovies()).Object;
            var actorsController = new MoviesController(repository);
            var result = actorsController.Get() as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(result.StatusCode);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode.Value);
            Assert.IsType<Movie[]>(result.Value);
            Assert.Equal(_movies.Length, ((Movie[])result.Value).Length);
        }

        [Fact]
        public void GetAllMoviesByActorTest()
        {
            var repository = 
                MockRepository(r => r.GetAllMoviesByActor(It.IsAny<int>())).
                Object;
            var actorsController = new MoviesController(repository);
            var result = actorsController.GetByActor(It.IsAny<int>()) as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(result.StatusCode);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode.Value);
            Assert.IsType<Movie[]>(result.Value);
            Assert.Equal(_movies.Length, ((Movie[])result.Value).Length);
        }

        [Fact]
        public void GetAllMoviesByProductionYearTest()
        {
            var repository = 
                MockRepository(r => r.GetAllMoviesByProductionYear(It.IsAny<int>())).
                Object;
            var actorsController = new MoviesController(repository);
            var result = actorsController.GetByYear(It.IsAny<int>()) as OkObjectResult;

            Assert.NotNull(result);
            Assert.NotNull(result.StatusCode);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode.Value);
            Assert.IsType<Movie[]>(result.Value);
            Assert.Equal(_movies.Length, ((Movie[])result.Value).Length);
        }

        [Fact]
        public void AddNewMovieTest()
        {
            var repository = MockRepository(r => r.AddNewMovie(It.IsAny<Movie>()));
            var actorsController = new MoviesController(repository.Object);
            actorsController.Post(It.IsAny<Movie>());
            
            repository.Verify(r => r.AddNewMovie(It.IsAny<Movie>()));
        }

        [Fact]
        public void UpdateMovieTest()
        {
            var repository = MockRepository(r => r.UpdateMovie(It.IsAny<Movie>()));
            var actorsController = new MoviesController(repository.Object);
            actorsController.Put(It.IsAny<Movie>());

            repository.Verify(r => r.UpdateMovie(It.IsAny<Movie>()));
        }

        [Fact]
        public void DeleteMovieTest()
        {
            var repository = MockRepository(r => r.DeleteMovie(It.IsAny<int>()));
            var actorsController = new MoviesController(repository.Object);
            actorsController.Delete(It.IsAny<int>());

            repository.Verify(r => r.DeleteMovie(It.IsAny<int>()));
        }

        private Mock<IMovieRepository> MockRepository(Expression<Func<IMovieRepository, IEnumerable<Movie>>> action)
        {
            var repository = new Mock<IMovieRepository>();
            repository.Setup(action).
            Returns(_movies);

            return repository;
        }

        private Mock<IMovieRepository> MockRepository(Expression<Action<IMovieRepository>> action)
        {
            var repository = new Mock<IMovieRepository>();
            repository.Setup(action);

            return repository;
        }
    }
}
