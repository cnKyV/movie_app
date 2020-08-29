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
    public static class IgnoreVirtualExtensions
    {
        public static IMappingExpression<TSource, TDestination>
               IgnoreAllVirtual<TSource, TDestination>(
                   this IMappingExpression<TSource, TDestination> expression)
        {
            var desType = typeof(TDestination);
            foreach (var property in desType.GetProperties().Where(p =>
                                     p.GetGetMethod().IsVirtual))
            {
                expression.ForMember(property.Name, opt => opt.Ignore());
            }

            return expression;
        }
    }
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            CreateMap<Movie, MovieResponseModel>();
               
            CreateMap<MovieCreateModel, Movie>()
                .ForMember(i => i.Actors, j => j.MapFrom(k => new List<ActorMovie>()));
            CreateMap<Movie, MovieCreateModel>();
                
            CreateMap<Actor, ActorMovie>();
            CreateMap<MovieUpdateModel, Movie>()
                .ForMember(i => i.Actors, j => j.MapFrom(k => new List<ActorMovie>()));
        }

    }
}
