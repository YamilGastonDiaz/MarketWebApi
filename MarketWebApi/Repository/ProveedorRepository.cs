using MarketWebApi.Data;
using MarketWebApi.Interfaces;
using MarketWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketWebApi.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly DB_MiniMarketContext _context;

        public ProveedorRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> GetProveedores()
        {
            return await _context.Proveedores.Where(p => p.Estado).ToListAsync();
        }

        public async Task<Proveedor> GetProveedor(int id)
        {
            return (await _context.Proveedores.FirstOrDefaultAsync(p => p.Proveedor_id == id && p.Estado))!;
        }

        public async Task<Proveedor> GetProveedor(string nombre)
        {
            return (await _context.Proveedores.FirstOrDefaultAsync(p => p.Nombre == nombre && p.Estado))!;
        }

        public async Task<bool> CuitExiste(string cuit)
        {
            var cuitLimpio = cuit.Trim();

            return await _context.Proveedores.AnyAsync(p => p.CUIT == cuitLimpio && p.Estado);
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<Proveedor> Add(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await Save();
            return proveedor;
        }

        public async Task<bool> Update(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            return await Save();
        }

        public async Task<bool> Delete(int id)
        {
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.Proveedor_id == id && p.Estado);

            if(proveedor == null)
            {
                return false;
            }

            proveedor.Estado = false;

            return await Save();
        }
    }
}
