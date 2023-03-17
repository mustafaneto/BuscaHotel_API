using BuscaHotel_HotelAPI.Models;
using System.Linq.Expressions;

namespace BuscaHotel_HotelAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true);

        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
