using MarketWebApi.Models;

namespace MarketWebApi.Interfaces
{
    public interface ICategoriaRepository
    {
        IQueryable<Categoria> GetCategorias();
        Task<Categoria> GetCategoria(int id);
        Task<Categoria> GetCategoria(string descripcion);
        Task<Categoria> Add(Categoria categoria);
        Task<bool> Update(Categoria categoria);
        Task<bool> Delete(int id);
        Task<bool> CategoriaExiste(int categoriaId);
        Task<bool> NombreExiste(string descripcion);
        Task<bool> Save();
    }
}
