using MarketWebApi.Models;

namespace MarketWebApi.Interfaces
{
    public interface ITiposEmpaqueRepository
    {
        Task<IEnumerable<TiposEmpaque>> GetTiposEmpaques();
        Task<TiposEmpaque> GetTiposEmpaque(int id);
        Task<TiposEmpaque> GetTiposEmpaque(string descripcion);
        Task<TiposEmpaque> Add(TiposEmpaque empaque);
        Task<bool> Update(TiposEmpaque empaque);
        Task<bool> Delete(int id);
        Task<bool> NombreExiste(string descripcion);
        Task<bool> Save();
    }
}
