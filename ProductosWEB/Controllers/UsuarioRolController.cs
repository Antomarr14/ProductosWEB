using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioRolController : ControllerBase
    {
        private readonly UsuarioRolServices _usuarioRolService;

        public UsuarioController(UsuarioRolServices usuarioRolService)
        {
            _usuarioRolService = usuarioRolService;
        }

        // GET: api/UsuarioRol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRol>>> Index()
        {
            var usuarioRoles = await _usuarioRolService.GetUsuarioRolesAsync();
            return Ok(usuarioRoles);
        }

        // GET: api/usuarUsuarioRol
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRol>> Details(int id)
        {
            var usuarioRol = await _usuarioService.GetUsuarioRolById(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }
            return Ok(usuarioRol);
        }

        // POST: api/UsuarioRol
        [HttpPost]
        public async Task<ActionResult<UsuarioRol>> Create([FromBody] UsuarioRol usuarioRol)
        {
            if (ModelState.IsValid)
            {
                await _usuarioRolService.CreateUsuarioRol(UsuarioRol);
                return CreatedAtAction(nameof(Details), new { id = usuarioRol.Id }, usuarioRol);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/UsuarioRol
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _usuarioRolService.UpdateUsuario(usuarioRol);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/UsuarioRol
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarioRol = await _usuarioRolService.GetUsuarioById(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            await _ServiceUsuarioRol.DeleteUsuarioRol(id);
            return NoContent();
        }
    }
}
