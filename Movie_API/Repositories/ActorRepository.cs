using Microsoft.EntityFrameworkCore;
using Movie_API.Entities;
using Movie_API.Interfaces;
using Movie_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Repositories
{
    public class ActorRepository :IActorRepository
    {
        private readonly MovieDbContext _movieDbContext;
        
            public ActorRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
            
        }
        public IEnumerable<Actor> GetAll()
        {
            var actor = _movieDbContext.Actors;
            
            return actor;
        }
        public Actor GetById(int id)
        {
            var movie = _movieDbContext.Actors.Include(i=> i.Movies).FirstOrDefault(i => i.Id == id);
            return movie;
        }


        public Actor Create(Actor actor)
        {

            try
            {
                _movieDbContext.Actors.Add(actor);
                _movieDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return null;
            }
            return actor;

        }

        public bool Update(Actor actor)
        {
            var actors = _movieDbContext.Actors.FirstOrDefault(i => i.Id == actor.Id);
            actors.Name = actor.Name;
            actors.Surname = actor.Surname;
            actors.Age = actor.Age;
            actors.Movies = actor.Movies;
            try
            {
                _movieDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool DeleteById(int id)
        {
            var actor = _movieDbContext.Actors.FirstOrDefault(i => i.Id == id);
            try
            {
                _movieDbContext.Remove(actor);
                _movieDbContext.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
