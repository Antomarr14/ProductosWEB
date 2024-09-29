using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Services;
using ProductosWEB.Models; // Asegúrate de incluir el espacio de nombres correcto para Compra
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly CompraService _compraService;

        public CompraController(CompraService compraService)
        {
            _compraService = compraService;
        }

        // GET: api/compra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> Index()
        {
            var compras = await _compraService.GetComprasAsync();
            return Ok(compras);
        }

        // GET: api/compra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> Details(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            if (compra == null)
            {
                return NotFound();
            }
            return Ok(compra);
        }

        // POST: api/compra
        [HttpPost]
        public async Task<ActionResult<Compra>> Create([FromBody] Compra compra)
        {
            if (ModelState.IsValid)
            {
                await _compraService.CreateCompra(compra);
                return CreatedAtAction(nameof(Details), new { id = compra.Id }, compra);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/compra/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Compra compra)
        {
            if (id != compra.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _compraService.UpdateCompra(compra);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/compra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var compra = await _compraService.GetCompraById(id);
            if (compra == null)
            {
                return NotFound();
            }

            await _compraService.DeleteCompra(id);
            return NoContent();
        }
    }
}