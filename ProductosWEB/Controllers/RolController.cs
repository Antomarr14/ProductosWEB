using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Models;
using ProductosWEB.Services;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

         // GET: api/role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> Index()
        {
            var roles = await _rolService.GetRolesAsync();
            return Ok(roles);
        }

        // GET: api/rol/
        [HttpGet("{id}")]
        public async Task<ActionResult<Rol>> Details(int id)
        {
            var rol = await _rolService.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        // POST: api/rol
        [HttpPost]
        public async Task<ActionResult<Rol>> Create([FromBody] Rol rol)
        {
            if (ModelState.IsValid)
            {
                await _rolService.CreateRol(rol);
                return CreatedAtAction(nameof(Details), new { id = rol.Id }, rol);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Rol
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Rol rol)
        {
            if (id != rol.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _rolService.UpdateRol(rol);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Rol
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var rol = await _rolService.GetRolById(id);
            if (rol == null)
            {
                return NotFound();
            }

            await _rolService.DeleteRol(id);
            return NoContent();
        }
    }
}
