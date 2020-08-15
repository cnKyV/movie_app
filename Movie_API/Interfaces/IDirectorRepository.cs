using Movie_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Interfaces
{
    public interface IDirectorRepository
    {
        IEnumerable<Director> GetAll();
        Director GetById(int id);
        bool Create(Director director);
        bool Update(Director director);
        bool DeleteById(int id);
    }
}
