using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models; // Asegúrate de incluir el espacio de nombres correcto para Articulo
using ProductosWEB.Services; // Asegúrate de incluir el espacio de nombres correcto para ArticuloService
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly ArticuloService _articuloService;

        public ArticuloController(ArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        // GET: api/articulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Articulo>>> GetArticulos()
        {
            var articulos = await _articuloService.GetArticulosAsync();
            return Ok(articulos);
        }

        // GET: api/articulo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Articulo>> GetArticulo(int id)
        {
            var articulo = await _articuloService.GetArticuloById(id);
            if (articulo == null)
            {
                return NotFound();
            }
            return Ok(articulo);
        }

        // POST: api/articulo
        [HttpPost]
        public async Task<ActionResult<Articulo>> CreateArticulo([FromBody] Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                var createdArticulo = await _articuloService.CreateArticulo(articulo);
                return CreatedAtAction(nameof(GetArticulo), new { id = createdArticulo.Id }, createdArticulo);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/articulo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticulo(int id, [FromBody] Articulo articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _articuloService.UpdateArticulo(articulo);
                return NoContent(); // Retornar un código 204 NoContent
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/articulo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var articulo = await _articuloService.GetArticuloById(id);
            if (articulo == null)
            {
                return NotFound();
            }

            await _articuloService.DeleteArticulo(id);
            return NoContent();
        }
    }
}