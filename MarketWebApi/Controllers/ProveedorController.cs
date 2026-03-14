using MarketWebApi.DTOs;
using MarketWebApi.Interfaces;
using MarketWebApi.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace MarketWebApi.Controllers
{
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorController(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProveedorDTO>>> GetProveedores()
        {
            var proveedores = await _proveedorRepository.GetProveedores();

            return Ok(proveedores.Select(p => p.ToProveedorDto()));
        }

        [HttpGet("id/{id:int}", Name = "ObtenerProveedor")]
        public async Task<ActionResult<ProveedorDTO>> GetProveedor(int id)
        {
            var proveedor = await _proveedorRepository.GetProveedor(id);

            if(proveedor == null)
            {
                return NotFound();
            }

            var resultado = proveedor.ToProveedorDto();

            return Ok(resultado);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<ProveedorDTO>> GetProveedor(string descripcion)
        {
            var proveedor = await _proveedorRepository.GetProveedor(descripcion);

            if(proveedor == null)
            {
                return NotFound();
            }

            var resultado = proveedor.ToProveedorDto();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProveedorDTO dto)
        {
            if(await _proveedorRepository.CuitExiste(dto.CUIT!))
            {
                return BadRequest("El proveedor ya existe");
            }

            var proveedor = dto.ToProveedor();

            var nuevoProveedor = await _proveedorRepository.Add(proveedor);

            var proveedorDto = nuevoProveedor.ToProveedorDto();

            return CreatedAtRoute("ObtenerProveedor", new { id = nuevoProveedor.Proveedor_id }, proveedorDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateProveedorDTO dto)
        {
            var proveedor = await _proveedorRepository.GetProveedor(id);

            if(proveedor == null)
            {
                return NotFound();
            }

            dto.UpdateProveedor(proveedor);

            await _proveedorRepository.Update(proveedor);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _proveedorRepository.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
