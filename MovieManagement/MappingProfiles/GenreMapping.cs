// MappingProfiles/GenreMappingProfile.cs
using AutoMapper;
using MovieManagement.DTOs;
using MovieManagement.Models;

namespace MovieManagement.MappingProfiles
{
    public class GenreMappingProfile : Profile
    {
        public GenreMappingProfile()
        {
            // Genre to GenreDTO
            CreateMap<Genre, GenreDTO>();
            
            // DTO to Genre
            CreateMap<GenreCreateDTO, Genre>();
            
        }
    }
}