using MarketWebApi.DTOs;
using MarketWebApi.Models;

namespace MarketWebApi.Mapping
{
    public static class MarcaMapper
    {
        public static MarcaDTO ToMarcaDto(this Marca marca)
        {
            return new MarcaDTO
            {
                Marca_id = marca.Marca_id,
                Descripcion = marca.Descripcion
            };
        }

        public static Marca ToMarca(this CreateMarcaDTO dto)
        {
            return new Marca
            {
                Descripcion = dto.Descripcion.Trim()
            };
        }

        public static void UpdateMarca(this UpdateMarcaDTO dto, Marca marca)
        {
            marca.Descripcion = dto.Descripcion.Trim();
        }
    }
}
