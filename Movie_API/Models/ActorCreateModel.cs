using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Models
{
    public class ActorCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public IEnumerable<int> MovieId { get; set; }
    }
}
