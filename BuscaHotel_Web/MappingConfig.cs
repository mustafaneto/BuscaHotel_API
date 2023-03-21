using AutoMapper;
using BuscaHotel_Web.Models.Dto;

namespace BuscaHotel_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<HotelDTO, HotelCreateDTO>().ReverseMap();
            CreateMap<HotelDTO, HotelUpdateDTO>().ReverseMap();


            CreateMap<HotelNumberDTO, HotelNumberCreateDTO>().ReverseMap();
            CreateMap<HotelNumberDTO, HotelNumberUpdateDTO>().ReverseMap();
        }
    }
}


