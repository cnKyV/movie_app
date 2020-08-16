using Movie_API.Entities;
using Movie_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Interfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        Movie Create(Movie movie);
        Movie Update(Movie movie);
        bool DeleteById(int id);
    }
}
