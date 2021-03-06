﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movie_API.Entities;
using Movie_API.Interfaces;
using Movie_API.Mapping;
using Movie_API.Models;
using Movie_API.Models.ResponseModels;
using Movie_API.Repositories;

namespace Movie_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ActorController : ControllerBase
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMovieRepository _movieRepository;     
        private readonly IMapper _mapper;
        public ActorController(IActorRepository actorRepository, IMapper mapper, IMovieRepository movieRepository)
        {
            _actorRepository = actorRepository;
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Create(ActorCreateModel actorCreateModel)
        {
            //Actor actor = new Actor();
            //actor.Name = actorCreateModel.Name;
            //actor.Surname = actorCreateModel.Surname;
            //actor.Age = actorCreateModel.Age;
            //_actorRepository.Create(actor);
            //return Ok(actorCreateModel);
            Actor actor = _mapper.Map<Actor>(actorCreateModel);
            
            foreach (var actor1 in actorCreateModel.MovieId)
            {
                ActorMovie actorMovie = new ActorMovie();
                actorMovie.Movie = _movieRepository.GetById(actor1);
                actor.Movies.Add(actorMovie);
            }
            ActorResponseModel actorResponse = _mapper.Map<ActorResponseModel>(_actorRepository.Create(actor));
            return Ok(actorResponse);
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            IEnumerable<ActorResponseModel> actorResponses = _mapper.Map<IEnumerable<ActorResponseModel>>(_actorRepository.GetAll());
            return Ok(actorResponses);
        }      
        [HttpPost]
        [Route("ReturnNameById")]
        public IActionResult ReturnNameById([FromBody]IEnumerable<int> id)
        {
            return Ok(_actorRepository.ReturnNamesById(id));
        }        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            ActorResponseModel actorResponse = _mapper.Map<ActorResponseModel>(_actorRepository.GetById(id));
            return Ok(actorResponse);
        }
        [HttpPut]
        public IActionResult Update(ActorUpdateModel actorUpdateModel)
        {
            Actor actor = _mapper.Map<Actor>(actorUpdateModel);
            ActorResponseModel actorresponse = _mapper.Map<ActorResponseModel>(_actorRepository.Update(actor));
            return Ok(actorresponse);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            return Ok(_actorRepository.DeleteById(id));
        }
    }
}
