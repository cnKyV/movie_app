using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public ICollection<ActorMovie> Actors{ get; set; }
    }
}
