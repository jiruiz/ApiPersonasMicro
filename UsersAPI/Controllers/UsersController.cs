using Microsoft.AspNetCore.Mvc;
using UsersAPI.DTOs;
using UsersAPI.Models;
using UsersAPI.Services;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _svc;
        public UsersController(IUsersService svc) => _svc = svc;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var (ok, error, data) = await _svc.RegisterAsync(dto);
            if (!ok) return BadRequest(new { error });
            return CreatedAtAction(nameof(GetById), new { id = data!.IdUser }, data);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            // En esta versión simple, no hacemos fetch directo.
            // Podrías agregar un método en el servicio o usar el contexto.
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var (ok, error) = await _svc.LoginAsync(dto);
            if (!ok) return Unauthorized(new { error });
            return Ok(new { message = "Login OK" /* aquí iría el JWT */ });
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDto dto)
        {
            var (ok, error, data) = await _svc.UpdateAsync(id, dto);
            if (!ok) return BadRequest(new { error });
            return Ok(data);
        }

        [HttpPut("{id:int}/password")]
        public async Task<IActionResult> ChangePassword(int id, [FromBody] UserPasswordChangeDto dto)
        {
            var (ok, error) = await _svc.ChangePasswordAsync(id, dto);
            if (!ok) return BadRequest(new { error });
            return NoContent();
        }
    }
}