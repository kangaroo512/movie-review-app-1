using AutoMapper;
using Movie_Review_API.DTOs.Movies;
using Movie_Review_API.Models;

namespace Movie_Review_API.AutoMappers
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<MovieInsertDTO, Movie>();
            CreateMap<Movie, MovieGetDTO>();
        }
    }
}
