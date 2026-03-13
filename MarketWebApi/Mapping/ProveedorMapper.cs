using MarketWebApi.DTOs;
using MarketWebApi.Models;

namespace MarketWebApi.Mapping
{
    public static class ProveedorMapper
    {
        public static ProveedorDTO ToProveedorDto(this Proveedor proveedor)
        {
            return new ProveedorDTO
            {
                Proveedor_id = proveedor.Proveedor_id,
                Nombre = proveedor.Nombre,
                CUIT = proveedor.CUIT,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email,
                Empresa = proveedor.Empresa
            };
        }

        public static Proveedor ToProveedor(this CreateProveedorDTO dto)
        {
            return new Proveedor
            {
                Nombre = dto.Nombre,
                CUIT = dto.CUIT,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Empresa = dto.Empresa
            };
        }

        public static void UpdateProveedor(this UpdateProveedorDTO dto, Proveedor proveedor)
        {
            proveedor.Nombre = dto.Nombre.Trim();
            proveedor.CUIT = dto.CUIT.Trim();
            proveedor.Direccion = dto.Direccion.Trim();
            proveedor.Telefono = dto.Telefono.Trim();
            proveedor.Email = dto.Email.Trim();
            proveedor.Empresa = dto.Empresa.Trim();
        }
    }
}
