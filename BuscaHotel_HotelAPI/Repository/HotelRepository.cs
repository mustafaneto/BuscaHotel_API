using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BuscaHotel_HotelAPI.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Hotel entity)
        {
           await _db.Hoteis.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Hotel> GetAsync(Expression<Func<Hotel, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Hotel> query = _db.Hoteis;

            if(!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Hotel>> GetAllAsync(Expression<Func<Hotel, bool>> filter = null)
        {
            IQueryable<Hotel> query = _db.Hoteis;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(Hotel entity)
        {
            _db.Hoteis.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hotel entity)
        {
            _db.Hoteis.Update(entity);
            await SaveAsync();
        }
    }
}
