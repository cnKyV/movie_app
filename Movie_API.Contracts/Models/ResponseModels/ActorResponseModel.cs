using Movie_API.Contracts.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Models.ResponseModels
{
    public class ActorResponseModel
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [NotMapped]
        public string FullName => Surname + ", " + Name;
        public int Age { get; set; }
        public ICollection<ActorMovieResponseModel> Movies { get; set; }
    }
}
