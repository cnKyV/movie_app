using AutoMapper;
using Movie_API.Contracts.Models.ResponseModels;
using Movie_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Mapping
{
    public class ActorMovieMappingProfile : Profile
    {
        public ActorMovieMappingProfile()
        {
            CreateMap<ActorMovie, ActorMovieResponseModel>()
                .ForMember(i => i.ActorId, k => k.MapFrom(i => i.Actor.Id)).ForMember(i => i.MovieId, k => k.MapFrom(i => i.Movie.Id));

        }
    }
}
