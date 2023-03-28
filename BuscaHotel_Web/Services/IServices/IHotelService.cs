using BuscaHotel_Web.Models.Dto;

namespace BuscaHotel_Web.Services.IServices
{
    public interface IHotelService
    {
        Task<T> GetAllAsync<T>(string token);

        Task<T> GetAsync<T>(int id, string token);

        Task<T> CreateAsync<T>(HotelCreateDTO dto, string token);

        Task<T> UpdateAsync<T>(HotelUpdateDTO dto, string token);

        Task<T> DeleteAsync<T>(int id, string token);   
    }
}
