using BuscaHotel_HotelAPI.Models.Dto;

namespace BuscaHotel_HotelAPI.Data
{
    public static class HotelStore
    {
        public static List<HotelDTO> hotelList= new List<HotelDTO>
        {
             new HotelDTO {Id = 1, Nome = "Rio Branco"},
             new HotelDTO { Id = 2, Nome = "Cruzeiro do Sul" }
        };
    }
}
