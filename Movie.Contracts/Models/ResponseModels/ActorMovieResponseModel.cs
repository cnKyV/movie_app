using System;
using System.Collections.Generic;
using System.Text;

namespace Movie_API.Contracts.Models.ResponseModels
{
   public class ActorMovieResponseModel
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }
    }
}
