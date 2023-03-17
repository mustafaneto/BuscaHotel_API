using BuscaHotel_HotelAPI.Models;
using System.Linq.Expressions;

namespace BuscaHotel_HotelAPI.Repository.IRepository
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<Hotel> UpdateAsync(Hotel entity);
    }
}
