using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_API.Entities;
using Movie_API.Interfaces;
using Movie_API.Models;
using Movie_API.Repositories;

namespace Movie_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        private readonly MovieDbContext _movieDbContext;
        public ActorController(IActorRepository actorRepository)
        {
            _actorRepository = actorRepository;
        }
        [HttpPost]
        public IActionResult Create(ActorCreateModel actorCreateModel)
        {
            Actor actor = new Actor();
            actor.Name = actorCreateModel.Name;
            actor.Surname = actorCreateModel.Surname;
            actor.Age = actorCreateModel.Age;
            _actorRepository.Create(actor);
            return Ok(actorCreateModel);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_actorRepository.GetAll());
        }        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_actorRepository.GetById(id));
        }
        [HttpPut]
        public IActionResult Update(ActorUpdateModel actorUpdateModel)
        {
            Actor actor = new Actor();
            actor.Id = actorUpdateModel.Id;
            actor.Name = actorUpdateModel.Name;
            actor.Surname = actorUpdateModel.Surname;
            actor.Age = actorUpdateModel.Age;
            return Ok(_actorRepository.Update(actor));
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            return Ok(_actorRepository.DeleteById(id));
        }
    }
}
