using MarketWebApi.Data;
using MarketWebApi.Interfaces;
using MarketWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWebApi.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DB_MiniMarketContext _context;

        public CategoriaRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _context.Categorias.Where(c => c.Estado).ToListAsync();
        }

        public async Task<Categoria> GetCategoria(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> GetCategoria(string descripcion)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Descripcion == descripcion);
        }

        public async Task<bool> CategoriaExiste(int id)
        {
            return await _context.Categorias.AnyAsync(c => c.Categoria_id == id);
        }

        public async Task<bool> NombreExiste(string descripcion)
        {
            return await _context.Categorias.
                AnyAsync(c => c.Descripcion == descripcion.Trim() && c.Estado);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false; ;
        }

        public async Task<Categoria> Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await Save();
            return categoria;
        }

        public async Task<bool> Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            return await Save();   
        }

        public async Task<bool> Delete(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.Categoria_id == id);

            if (categoria == null)
            {
                return false;
            }

            categoria.Estado = false;

            return await Update(categoria);
        }
    }
}
