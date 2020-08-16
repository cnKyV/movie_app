using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_API.Entities;
using Movie_API.Interfaces;
using Movie_API.Models;
using Movie_API.Models.ResponseModels;

namespace Movie_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly MovieDbContext _movieDbContext;
        private readonly IMovieRepository _movieRepository;
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;



        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, MovieDbContext movieDbContext, IMovieRepository movieRepository, IActorRepository actorRepository, IMapper mapper)
        {
            _logger = logger;
            _movieDbContext = movieDbContext; //dependency injection
            _movieRepository = movieRepository;
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(MovieCreateModel movieCreateModel)
        {
            #region automappersiz
            //Movie movie = new Movie();
            //movie.Name = movieCreateModel.Name;
            //movie.Description = movieCreateModel.Description;
            //movie.Length = movieCreateModel.Length;
            //movie.Actors = new List<ActorMovie>();
            //foreach (var actor in movieCreateModel.Actors)
            //{
            //    ActorMovie actorMovie = new ActorMovie();
            //    var query = _actorRepository.GetById(actor);
            //    actorMovie.Actor = query;
            //    actorMovie.Movie = movie;
            //    movie.Actors.Add(actorMovie);
            //}

            #endregion

            Movie movieResponseModel = _mapper.Map<Movie>(movieCreateModel);
      
            foreach (var actor in movieCreateModel.Actors)
            {
                ActorMovie actor1 = new ActorMovie();
                actor1.Actor = _actorRepository.GetById(actor);
                movieResponseModel.Actors.Add(actor1);
            }
            
            MovieResponseModel movieResponse = _mapper.Map<MovieResponseModel>(_movieRepository.Create(movieResponseModel));
            foreach (var item in movieResponse.Actors)
            {
                item.Movie = null;
                item.Actor.Movies = null;
            }
            return Ok(movieResponse);
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            #region AutoMapper'siz
            List<MovieResponseModel> movieResponseModels = new List<MovieResponseModel>();
            foreach (var item in _movieRepository.GetAll())//Mapping
            {
                MovieResponseModel movieResponseModel = new MovieResponseModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Length = item.Length
                };
                movieResponseModels.Add(movieResponseModel);

            }
            #endregion

            //AutoMapper
            IEnumerable<MovieResponseModel> movieResponses = _mapper.Map<IEnumerable<MovieResponseModel>>(_movieRepository.GetAll());
            return Ok(movieResponses);
            
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            MovieResponseModel movieResponses = _mapper.Map<MovieResponseModel>(movie);
 
            return Ok(movieResponses);
        }
        [HttpPut]
        public IActionResult Update(MovieUpdateModel movieUpdateModel)
        {
            Movie movie = _mapper.Map<Movie>(movieUpdateModel);
            foreach (var actor in movieUpdateModel.Actors)
            {
                ActorMovie actor1 = new ActorMovie();
                actor1.Actor = _actorRepository.GetById(actor);
                movie.Actors.Add(actor1);
            }
            MovieResponseModel movieResponse = _mapper.Map<MovieResponseModel>(_movieRepository.Update(movie));
            foreach (var item in movieResponse.Actors)
            {
                item.Movie = null;
                item.Actor.Movies = null;
            }
            return Ok(movieResponse);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_movieRepository.DeleteById(id));
        }

    }
}
