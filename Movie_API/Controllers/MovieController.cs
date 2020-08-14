using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Movie_API.Entities;
using Movie_API.Interfaces;
using Movie_API.Models;

namespace Movie_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly MovieDbContext _movieDbContext;
        private readonly IMovieRepository _movieRepository;



        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, MovieDbContext movieDbContext, IMovieRepository movieRepository)
        {
            _logger = logger;
            _movieDbContext = movieDbContext; //dependency injection
            _movieRepository = movieRepository;
        }

        [HttpPost]
        public IActionResult Create(MovieCreateModel movieCreateModel)
        {

            return Ok(_movieRepository.Create(movieCreateModel));
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_movieRepository.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        [HttpPut]
        public IActionResult Update(MovieUpdateModel model)
        {
            return Ok(_movieRepository.Update(model));
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_movieRepository.DeleteById(id));
        }

    }
}
