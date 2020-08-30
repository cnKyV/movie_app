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
        Actor Update(Actor actor);
        IEnumerable<string> ReturnNamesById(IEnumerable<int> id);
        bool DeleteById(int id);
    }
}
