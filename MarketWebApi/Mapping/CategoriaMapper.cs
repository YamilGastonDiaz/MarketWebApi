using MarketWebApi.DTOs;
using MarketWebApi.Models;

namespace MarketWebApi.Mapping
{
    public static class CategoriaMapper
    {
        public static CategoriaDTO ToCategoriaDto(this Categoria categoria)
        {
            return new CategoriaDTO
            {
                Categoria_id = categoria.Categoria_id,
                Descripcion = categoria.Descripcion
            };
        }

        public static Categoria ToCategoria(this CreateCategoriaDTO dto)
        {
            return new Categoria
            {
                Descripcion = dto.Descripcion.Trim()
            };
        }

        public static void UpdateCategoria(this UpdateCategoriaDTO dto, Categoria categoria)
        {
            categoria.Descripcion = dto.Descripcion.Trim();
        }
    }
}
