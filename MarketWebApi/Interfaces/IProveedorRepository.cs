using MarketWebApi.Models;

namespace MarketWebApi.Interfaces
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetProveedores();
        Task<Proveedor> GetProveedor(int id);
        Task<Proveedor> GetProveedor(string cuit);
        Task<Proveedor> Add(Proveedor proveedor);
        Task<bool> Update(Proveedor proveedor);
        Task<bool> Delete(int id);
        Task<bool> CuitExiste(string cuit);
        Task<bool> Save();
    }
}
