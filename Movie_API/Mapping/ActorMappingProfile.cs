using AutoMapper;
using Movie_API.Entities;
using Movie_API.Models;
using Movie_API.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API.Mapping
{
    public class ActorMappingProfile : Profile
    {
        public ActorMappingProfile()
        {
            CreateMap<Actor, ActorResponseModel>();
            CreateMap<ActorCreateModel, Actor>()
                .ForMember(i => i.Movies, j => j.MapFrom(k => new List<ActorMovie>()));
        }
    }
}
