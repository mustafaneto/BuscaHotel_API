using BuscaHotel_HotelAPI.Models;
using System.Linq.Expressions;

namespace BuscaHotel_HotelAPI.Repository.IRepository
{
    public interface IHotelNumberRepository : IRepository<HotelNumber>
    {
        Task<HotelNumber> UpdateAsync(HotelNumber entity);
    }
}
