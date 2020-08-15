using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Entities
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [NotMapped]
        public string FullName => Surname + ", " + Name;
        public ICollection<Movie> Movies { get; set; }
    }
}
