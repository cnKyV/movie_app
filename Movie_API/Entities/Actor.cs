using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Entities
{
    public class Actor
    {

        [Key] //pk
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [NotMapped] //exclude from db
        public string FullName => Surname +", "+ Name;
        public int Age { get; set; }
        public ICollection<ActorMovie> Movies{ get; set; }
    }
}
