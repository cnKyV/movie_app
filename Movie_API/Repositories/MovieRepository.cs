using Microsoft.AspNetCore.Mvc;
using Movie_API.Entities;
using Movie_API.Interfaces;
using Movie_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;
        public MovieRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }

        #region Get
        public IEnumerable<Movie> GetAll()
        {
            var movie = _movieDbContext.Movies;
            return movie;
        }
        public Movie GetById(int id)
        {
            var movie = _movieDbContext.Movies.FirstOrDefault(i => i.Id == id);
            return movie;
        }
        #endregion

        public bool Create(MovieCreateModel model)
        {
            var movie = new Movie();
            movie.Name = model.Name;
            movie.Description = model.Description;
            movie.Length = model.Length;
            try
            {
                _movieDbContext.Movies.Add(movie);
                _movieDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
            
        }

        public bool Update(MovieUpdateModel model)
        {
            var movie = _movieDbContext.Movies.FirstOrDefault(i => i.Id == model.Id);
            movie.Name = model.Name;
            movie.Description = model.Description;
            movie.Length = model.Length;
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
            var movie = _movieDbContext.Movies.FirstOrDefault(i => i.Id == id);
            try
            {
                _movieDbContext.Remove(movie);
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
