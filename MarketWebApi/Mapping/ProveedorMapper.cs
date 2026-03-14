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
                Nombre = dto.Nombre!,
                CUIT = dto.CUIT,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Empresa = dto.Empresa
            };
        }

        public static void UpdateProveedor(this UpdateProveedorDTO dto, Proveedor proveedor)
        {
            if (!string.IsNullOrWhiteSpace(dto.Nombre))
            {
                proveedor.Nombre = dto.Nombre!.Trim();
            }
                
            if (!string.IsNullOrWhiteSpace(dto.CUIT))
            {
                proveedor.CUIT = dto.CUIT!.Trim();
            }
                
            if (!string.IsNullOrWhiteSpace(dto.Direccion))
            {
                proveedor.Direccion = dto.Direccion!.Trim();
            }
                
            if (!string.IsNullOrWhiteSpace(dto.Telefono))
            {
                proveedor.Telefono = dto.Telefono!.Trim();
            }
               
            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                proveedor.Email = dto.Email!.Trim();
            }
                
            if (!string.IsNullOrWhiteSpace(dto.Empresa))
            {
                proveedor.Empresa = dto.Empresa!.Trim();
            }
        }
    }
}
