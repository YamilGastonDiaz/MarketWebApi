using MarketWebApi.Data;
using MarketWebApi.Interfaces;
using MarketWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWebApi.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DB_MiniMarketContext _context;

        public MarcaRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Marca>> GetMarcas()
        {
            return await _context.Marcas.Where(m => m.Estado).ToListAsync();
        }

        public async Task<Marca> GetMarca(int id)
        {
            return await _context.Marcas.FindAsync(id);
        }

        public async Task<Marca> GetMarca(string descripcion)
        {
            return await _context.Marcas.FirstOrDefaultAsync(m => m.Descripcion == descripcion);
        }

        public async Task<bool> MarcaExiste(int id)
        {
            return await _context.Marcas.AnyAsync(m => m.Marca_id == id);
        }

        public async Task<bool> NombreExiste(string descripcion)
        {
            return await _context.Marcas.
                AnyAsync(m => m.Descripcion == descripcion.Trim() && m.Estado);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<Marca> Add(Marca marca)
        {
            _context.Marcas.Add(marca);
            await Save();
            return marca;
        }

        public async Task<bool> Update(Marca marca)
        {
            _context.Update(marca);
            return await Save();
        }

        public async Task<bool> Delete(int id)
        {
            var marca = await _context.Marcas.FirstOrDefaultAsync(m => m.Marca_id == id);

            if(marca == null)
            {
                return false;
            }

            marca.Estado = false;

            return await Update(marca);
        }
    }
}
