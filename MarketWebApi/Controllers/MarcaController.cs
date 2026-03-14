using MarketWebApi.DTOs;
using MarketWebApi.Interfaces;
using MarketWebApi.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace MarketWebApi.Controllers
{
    [ApiController]
    [Route("api/marca")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDTO>>> GetMarcas()
        {
            var marcas = await _marcaRepository.GetMarcas();

            return Ok(marcas.Select(m => m.ToMarcaDto()));
        }

        [HttpGet("id/{id:int}", Name = "ObtenerMarca")]
        public async Task<ActionResult<MarcaDTO>> GetMarca(int id)
        {
            var marca = await _marcaRepository.GetMarca(id);

            if (marca == null)
            {
                return NotFound();
            }

            var resultado = marca.ToMarcaDto();

            return Ok(resultado);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<MarcaDTO>> GetMarca(string descripcion)
        {
            var marca = await _marcaRepository.GetMarca(descripcion);

            if (marca == null)
            {
                return NotFound();
            }

            var resultado = marca.ToMarcaDto();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateMarcaDTO dto)
        {
            if (await _marcaRepository.NombreExiste(dto.Descripcion!))
            {
                return BadRequest("La marca ya existe");
            }

            var marca = dto.ToMarca();

            var nuevaMarca = await _marcaRepository.Add(marca);

            var marcaDto = nuevaMarca.ToMarcaDto();

            return CreatedAtRoute("ObtenerMarca", new { id = nuevaMarca.Marca_id }, marcaDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateMarcaDTO dto)
        {
            var marca = await _marcaRepository.GetMarca(id);

            if(marca == null)
            {
                return NotFound();
            }

            dto.UpdateMarca(marca);

            await _marcaRepository.Update(marca);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _marcaRepository.Delete(id);

            if(!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
