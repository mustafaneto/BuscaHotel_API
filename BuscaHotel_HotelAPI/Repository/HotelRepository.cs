using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BuscaHotel_HotelAPI.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<Hotel> UpdateAsync(Hotel entity)
        {
            entity.DataAtualizacao = DateTime.Now;
            _db.Hoteis.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
