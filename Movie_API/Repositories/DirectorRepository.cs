using Microsoft.EntityFrameworkCore;
using Movie_API.Entities;
using Movie_API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Repositories
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public DirectorRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public bool Create(Director director)
        {   
            try
            {
                _movieDbContext.Add(director);
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
            var query = _movieDbContext.Directors.FirstOrDefault(i => i.Id == id);

            try
            {
                _movieDbContext.Remove(query);
                _movieDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<Director> GetAll()
        {
            var directors = _movieDbContext.Directors.Include(i => i.Movies);
            return directors;
        }

        public Director GetById(int id)
        {
            var query = _movieDbContext.Directors.Include(i => i.Movies)
                .FirstOrDefault(i => i.Id == id);
            return query;
        }

        public bool Update(Director director)
        {
            var query = _movieDbContext.Directors.FirstOrDefault(i => i.Id == director.Id);
            query.Name = director.Name;
            query.Surname = director.Surname;
            query.Movies = director.Movies;
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
    }
}
