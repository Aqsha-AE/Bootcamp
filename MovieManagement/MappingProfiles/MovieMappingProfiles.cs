using AutoMapper;
using MovieManagement.DTOs;
using MovieManagement.Models;

namespace MovieManagement.MappingProfiles
{
    public class MovieMappingProfile : Profile
    {
        public MovieMappingProfile()
        {
            // Movie to MovieDTO
            CreateMap<Movie, MovieDTO>()
               .ForMember(dest => dest.GenreIds, opt =>
                   opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre.Name).ToList()));

            // DTO to Movie
            CreateMap<MovieCreateDTO, Movie>();
            CreateMap<MovieUpdateDTO, Movie>();

        }
    }
}