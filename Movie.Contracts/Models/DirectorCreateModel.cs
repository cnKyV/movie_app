
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Models
{
    public class DirectorCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<int> Movies { get; set; }
    }
}
