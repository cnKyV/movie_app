using Movie_API.Contracts.Models.ResponseModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Models.ResponseModels
{
    public class MovieResponseModel 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; }
        public ICollection<ActorMovieResponseModel> Actors { get; set; }
    }
}
