using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models;
using ProductosWEB.Services;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly PrestamoService _prestamoService;

        public PrestamoController(PrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        // GET: api/Prestamo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> Index()
        {
            var prestamos = await _prestamoService.GetAllPrestamosAsync();
            return Ok(prestamos);
        }

        // GET: api/Prestamo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> Details(int id)
        {
            var prestamo = await _prestamoService.GetPrestamoByIdAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return Ok(prestamo);
        }

        // POST: api/Prestamo
        [HttpPost]
        public async Task<ActionResult<Prestamo>> Create([FromBody] Prestamo prestamo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                prestamo.estado = "En Prestamo"; // Inicializar estado
                var createdPrestamo = await _prestamoService.CreatePrestamoAsync(prestamo);
                return CreatedAtAction(nameof(Details), new { id = createdPrestamo.Id }, createdPrestamo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al crear el préstamo.", error = ex.Message });
            }
        }

        // PUT: api/Prestamo/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Prestamo prestamo)
        {
            if (id != prestamo.Id)
            {
                return BadRequest("ID no coincide.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _prestamoService.UpdatePrestamoAsync(prestamo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al actualizar el préstamo.", error = ex.Message });
            }
        }

        // PATCH: api/Prestamo/Devolver/5
        [HttpPatch("Devolver/{id}")]
        public async Task<ActionResult> DevolverPrestamo(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }

            try
            {
                var result = await _prestamoService.MarkPrestamoAsReturnedAsync(id);
                if (!result)
                {
                    return BadRequest("Error al devolver el préstamo o ya ha sido devuelto.");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Ocurrió un error al devolver el préstamo.", error = ex.Message });
            }
        }
    }
}
