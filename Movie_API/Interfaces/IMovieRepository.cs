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
        bool Create(MovieCreateModel model);
        bool Update(MovieUpdateModel model);
        bool DeleteById(int id);
    }
}
