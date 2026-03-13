using MarketWebApi.Data;
using MarketWebApi.Interfaces;
using MarketWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWebApi.Repository
{
    public class TiposEmpaqueRepository : ITiposEmpaqueRepository
    {
        private readonly DB_MiniMarketContext _context;

        public TiposEmpaqueRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TiposEmpaque>> GetTiposEmpaques()
        {
            return await _context.TiposEmpaques.Where(e => e.Estado).ToListAsync();
        }

        public async Task<TiposEmpaque> GetTiposEmpaque(int id)
        {
            return await _context.TiposEmpaques.FirstOrDefaultAsync(e => e.Empaque_id == id && e.Estado);
        }

        public async Task<TiposEmpaque> GetTiposEmpaque(string descripcion)
        {
            return await _context.TiposEmpaques.FirstOrDefaultAsync(e => e.Descripcion == descripcion && e.Estado);
        }

        public async Task<bool> NombreExiste(string descripcion)
        {
            var descripcionLimpia = descripcion.Trim();

            return await _context.TiposEmpaques.
                AnyAsync(e => e.Descripcion == descripcionLimpia && e.Estado);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<TiposEmpaque> Add(TiposEmpaque empaque)
        {
            _context.TiposEmpaques.Add(empaque);
            await Save();
            return empaque;
        }

        public async Task<bool> Update(TiposEmpaque empaque)
        {
            _context.TiposEmpaques.Update(empaque);
            return await Save();
        }

        public async Task<bool> Delete(int id)
        {
            var empaque = await _context.TiposEmpaques.FirstOrDefaultAsync(e => e.Empaque_id == id && e.Estado);

            if(empaque == null) 
            {
                return false;
            }

            empaque.Estado = false;

            return await Save();
        }
    }
}
