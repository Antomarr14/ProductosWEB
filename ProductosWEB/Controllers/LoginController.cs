using Microsoft.AspNetCore.Mvc;
using ProductosWEB.Services;
using ProductosWEB.Models; // Asegúrate de incluir el espacio de nombres correcto para Login
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductosWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        // GET: api/login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Login>>> GetAllLogins()
        {
            var logins = await _loginService.GetLoginsAsync();
            return Ok(logins);
        }

        // GET: api/login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Login>> GetLoginById(int id)
        {
            var login = await _loginService.GetLoginById(id);
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }

        // POST: api/login
        [HttpPost]
        public async Task<ActionResult<Login>> CreateLogin([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                var createdLogin = await _loginService.CreateLogin(login);
                return CreatedAtAction(nameof(GetLoginById), new { id = createdLogin.Id }, createdLogin);
            }
            return BadRequest(ModelState);
        }

        // PUT: api/login/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateLogin(int id, [FromBody] Login login)
        {
            if (id != login.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _loginService.UpdateLogin(login);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/login/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLogin(int id)
        {
            var login = await _loginService.GetLoginById(id);
            if (login == null)
            {
                return NotFound();
            }

            await _loginService.DeleteLogin(id);
            return NoContent();
        }
    }
}