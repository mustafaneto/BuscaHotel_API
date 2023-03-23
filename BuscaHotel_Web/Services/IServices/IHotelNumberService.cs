using BuscaHotel_Web.Models.Dto;

namespace BuscaHotel_Web.Services.IServices
{
    public interface IHotelNumberService
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetAsync<T>(int id);

        Task<T> CreateAsync<T>(HotelNumberCreateDTO dto);

        Task<T> UpdateAsync<T>(HotelNumberUpdateDTO dto);

        Task<T> DeleteAsync<T>(int id);   
    }
}
