using Microsoft.AspNetCore.Mvc;
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
            var movie = _movieDbContext.Movies.Include(i=> i.Actors).ThenInclude(i=>i.Actor).FirstOrDefault(i => i.Id == id);
            return movie;
        }
        #endregion

        public Movie Create(Movie movie)
        {
           
            try
            {
                _movieDbContext.Movies.Add(movie);
                _movieDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return null;
            }
            return movie;
            
        }

        public Movie Update(Movie movie)
        {
            var query = _movieDbContext.Movies.FirstOrDefault(i => i.Id == movie.Id);
            query.Name = movie.Name;
            query.Description = movie.Description;
            query.Length = movie.Length;
            if (query.Actors != null)
            {
                query.Actors.Clear();
                foreach (var actor in movie.Actors)
                {
                    query.Actors.Add(actor);
                }
            }
            
            
            try
            {
                _movieDbContext.SaveChanges();
            }
            catch (Exception)
            {

                return null;
            }
            return query;
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
