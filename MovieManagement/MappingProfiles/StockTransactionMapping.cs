// MappingProfiles/StockTransactionMappingProfile.cs
using System.Transactions;
using AutoMapper;
using MovieManagement.DTOs;
using MovieManagement.Models;

namespace MovieManagement.MappingProfiles
{
    public class StockTransactionMappingProfile : Profile
    {
        public StockTransactionMappingProfile()
        {
            // StockTransaction to StockTransactionDTO
            CreateMap<StockTransaction, StockTransactionDTO>()
                .ForMember(dest => dest.MovieTitle, opt =>
                    opt.MapFrom(src => src.Movie != null ? src.Movie.Title : string.Empty))
                .ForMember(dest => dest.Type, opt =>
                    opt.MapFrom(src => src.Transaction.ToString()));
            
            CreateMap<StockTransactionCreateDTO, StockTransaction>()
                .ForMember(dest => dest.Transaction, opt => opt.MapFrom(src => 
                    (Transaction)Enum.Parse(typeof(Transaction), src.TransactionType)))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}