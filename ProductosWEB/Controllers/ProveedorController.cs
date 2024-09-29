using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models;
using ProductosWEB.Services;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ProveedorService _proveedorService;

        public ProveedorController(ProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        // GET: api/Proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> Index()
        {
            var proveedores = await _proveedorService.GetProveedoresAsync();
            return Ok(proveedores);
        }

        // GET: api/proveedor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> Details(int id)
        {
            var proveedor = await _proveedorService.GetProveedorById(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        // POST: api/proveedor
        [HttpPost]
        public async Task<ActionResult<Proveedor>> Create([FromBody] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                await _proveedorService.CreateProveedor(proveedor);
                return CreatedAtAction(nameof(Details), new { id = proveedor.Id }, proveedor);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/proveedor/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _proveedorService.UpdateProveedor(proveedor);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/proveedor/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var proveedor = await _proveedorService.GetProveedorById(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            await _proveedorService.DeleteProveedor(id);
            return NoContent();
        }
    }
}
