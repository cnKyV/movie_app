using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Entities
{
    public class ActorMovie
    {
        public int Id { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}
