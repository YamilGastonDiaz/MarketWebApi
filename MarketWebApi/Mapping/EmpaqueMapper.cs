using MarketWebApi.DTOs;
using MarketWebApi.Models;

namespace MarketWebApi.Mapping
{
    public static class EmpaqueMapper
    {
        public static EmpaqueDTO ToEmapaqueDto(this TiposEmpaque empaque)
        {
            return new EmpaqueDTO
            {
                Empaque_id = empaque.Empaque_id,
                Descripcion = empaque.Descripcion,
                CantidadUnidad = empaque.CantidadUnidad
            };
        }

        public static TiposEmpaque ToEmpaque(this CrearteEmpaqueDTO dto)
        {
            return new TiposEmpaque
            {
                Descripcion = dto.Descripcion.Trim(),
                CantidadUnidad = dto.CantidadUnidad
            };
        }

        public static void UpdateEmpaque(this UpdateEmpaqueDTO dto, TiposEmpaque empaque)
        {
            empaque.Descripcion = dto.Descripcion;
            empaque.CantidadUnidad = dto.CantidadUnidad;
        }
    }
}
