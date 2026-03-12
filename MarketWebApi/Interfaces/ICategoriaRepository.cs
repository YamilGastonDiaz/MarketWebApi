using MarketWebApi.Models;

namespace MarketWebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria> GetCategoria(int id);
        Task<Categoria> GetCategoria(string descripcion);
        Task<Categoria> Add(Categoria categoria);
        Task<bool> Update(Categoria categoria);
        Task<bool> Delete(int id);
        Task<bool> CategoriaExiste(int id);
        Task<bool> NombreExiste(string descripcion);
        Task<bool> Save();
    }
}
