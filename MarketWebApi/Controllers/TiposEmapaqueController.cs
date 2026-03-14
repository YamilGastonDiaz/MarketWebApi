using MarketWebApi.DTOs;
using MarketWebApi.Interfaces;
using MarketWebApi.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace MarketWebApi.Controllers
{
    [ApiController]
    [Route("api/tiposEmpaque")]
    public class TiposEmapaqueController : ControllerBase
    {
        private readonly ITiposEmpaqueRepository _empaqueRepository;

        public TiposEmapaqueController(ITiposEmpaqueRepository empaqueRepository)
        {
            _empaqueRepository = empaqueRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpaqueDTO>>> GetEmpaques()
        {
            var empaques = await _empaqueRepository.GetTiposEmpaques();

            return Ok(empaques.Select(e => e.ToEmapaqueDto()));
        }

        [HttpGet("id/{id:int}", Name = "ObtenerEmpaque")]
        public async Task<ActionResult<EmpaqueDTO>> GetEmpaque(int id)
        {
            var empaque = await _empaqueRepository.GetTiposEmpaque(id);

            if(empaque == null)
            {
                return NotFound();
            }

            var resultado = empaque.ToEmapaqueDto();

            return Ok(resultado);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<EmpaqueDTO>> GetEmpaque(string descripcion)
        {
            var empaque = await _empaqueRepository.GetTiposEmpaque(descripcion);

            if(empaque == null)
            {
                return NotFound();
            }

            var resultado = empaque.ToEmapaqueDto();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CrearteEmpaqueDTO dto)
        {
            if(await _empaqueRepository.NombreExiste(dto.Descripcion!))
            {
                return BadRequest("El empaque ya existe");
            }

            var empaque = dto.ToEmpaque();

            var nuevoEmpaque = await _empaqueRepository.Add(empaque);

            var empaqueDto = nuevoEmpaque.ToEmapaqueDto();

            return CreatedAtRoute("ObtenerEmpaque", new { id = nuevoEmpaque.Empaque_id }, empaqueDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateEmpaqueDTO dto)
        {
            var empaque = await _empaqueRepository.GetTiposEmpaque(id);

            if(empaque == null)
            {
                return NotFound();
            }

            dto.UpdateEmpaque(empaque);

            await _empaqueRepository.Update(empaque);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _empaqueRepository.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
