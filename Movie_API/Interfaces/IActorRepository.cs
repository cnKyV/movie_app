using Movie_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Interfaces
{
    public interface IActorRepository
    {
        IEnumerable<Actor> GetAll();
        Actor GetById(int id);
        Actor Create(Actor actor);
        bool Update(Actor actor);
        bool DeleteById(int id);
    }
}
