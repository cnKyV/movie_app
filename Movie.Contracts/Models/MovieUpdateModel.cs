using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Models
{
    public class MovieUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public IEnumerable<int> Actors { get; set; }
    }
}
