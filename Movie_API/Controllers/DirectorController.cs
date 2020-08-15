using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_API.Entities;
using Movie_API.Interfaces;
using Movie_API.Models;

namespace Movie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMovieRepository _movieRepository;
        public DirectorController(IDirectorRepository directorRepository, IMovieRepository movieRepository)
        {
            _directorRepository = directorRepository;
            _movieRepository = movieRepository;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_directorRepository.GetAll());
        }        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_directorRepository.GetById(id));
        }
        [HttpPost]
        public IActionResult Create(DirectorCreateModel directorCreateModel)
        {
            Director director = new Director();
            director.Name = directorCreateModel.Name;
            director.Surname = directorCreateModel.Surname;
            director.Movies = new List<Movie>();
            foreach (var movie in directorCreateModel.Movies)
            {
                var query = _movieRepository.GetById(movie);
                
                director.Movies.Add(query);
                
            }
            
            return Ok(_directorRepository.Create(director));
        }
        [HttpPut]
        public IActionResult Update(DirectorUpdateModel directorUpdateModel)
        {
            Director director = new Director();
            director.Id = directorUpdateModel.Id;
            director.Name = directorUpdateModel.Name;
            director.Surname = directorUpdateModel.Surname;
            director.Movies = new List<Movie>();
            foreach (var movie in directorUpdateModel.Movies)
            {
                director.Movies.Add(_movieRepository.GetById(movie));
                
            }
            return Ok(_directorRepository.Update(director));
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            return Ok(_directorRepository.DeleteById(id));
        }
    }
}
