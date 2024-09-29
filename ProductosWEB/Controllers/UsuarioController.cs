using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Services;
using ProductosWEB.Models; // Asegúrate de incluir el espacio de nombres correcto para Usuario
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioServices _usuarioService;

        public UsuarioController(UsuarioServices usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Index()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            return Ok(usuarios);
        }

        // GET: api/usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Details(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await _usuarioService.CreateUsuario(usuario);
                return CreatedAtAction(nameof(Details), new { id = usuario.Id }, usuario);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/usuario/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromBody] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _usuarioService.UpdateUsuario(usuario);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}