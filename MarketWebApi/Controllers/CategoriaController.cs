using MarketWebApi.DTOs;
using MarketWebApi.Interfaces;
using MarketWebApi.Mapping;
using MarketWebApi.Models;
using MarketWebApi.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketWebApi.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias([FromQuery] PaginacionDTO paginacionDTO)
        {
            var queryable =  _categoriaRepository.GetCategorias();

            await HttpContext.InsertParametrosPaginacion(queryable);

            var categorias = await queryable.OrderBy(c => c.Descripcion).Paginar(paginacionDTO).ToListAsync();

            return Ok(categorias.Select(c => c.ToCategoriaDto()));
        }

        [HttpGet("id/{id:int}", Name = "ObtenerCategoria")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetCategoria(id);

            if (categoria == null)
            {
                return NotFound();
            }

            var resultado = categoria.ToCategoriaDto();

            return Ok(resultado);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(string descripcion) 
        {
            var categoria =  await _categoriaRepository.GetCategoria(descripcion);

            if (categoria == null)
            {
                return NotFound();
            }

            var resultado = categoria.ToCategoriaDto();

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult>Post(CreateCategoriaDTO dto)
        {
            if (await _categoriaRepository.NombreExiste(dto.Descripcion)) 
            {
                return BadRequest("La categoría ya existe");
            }

            var categoria = dto.ToCategoria();

            var nuevaCategoria = await _categoriaRepository.Add(categoria);

            var categoriaDto = nuevaCategoria.ToCategoriaDto();

            return CreatedAtRoute("ObtenerCategoria", new {id = nuevaCategoria.Categoria_id}, categoriaDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateCategoriaDTO dto)
        {
            var categoria = await _categoriaRepository.GetCategoria(id);

            if(categoria == null)
            {
                return NotFound();
            }

            dto.UpdateCategoria(categoria);

            await _categoriaRepository.Update(categoria);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _categoriaRepository.Delete(id);

            if(!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
