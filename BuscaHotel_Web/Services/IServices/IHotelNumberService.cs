using BuscaHotel_Web.Models.Dto;

namespace BuscaHotel_Web.Services.IServices
{
    public interface IHotelNumberService
    {
        Task<T> GetAllAsync<T>(string token);

        Task<T> GetAsync<T>(int id, string token);

        Task<T> CreateAsync<T>(HotelNumberCreateDTO dto, string token);

        Task<T> UpdateAsync<T>(HotelNumberUpdateDTO dto, string token);

        Task<T> DeleteAsync<T>(int id, string token);   
    }
}
