using BuscaHotel_HotelAPI.Data;
using BuscaHotel_HotelAPI.Models;
using BuscaHotel_HotelAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace BuscaHotel_HotelAPI.Repository
{
    public class HotelNumberRepository : Repository<HotelNumber>, IHotelNumberRepository
    {
        private readonly ApplicationDbContext _db;

        public HotelNumberRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        public async Task<HotelNumber> UpdateAsync(HotelNumber entity)
        {
            entity.DataAtualizacao = DateTime.Now;
            _db.HotelNumbers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
