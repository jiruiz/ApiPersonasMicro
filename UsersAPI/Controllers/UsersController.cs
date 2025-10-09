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
        private readonly UsersService _svc;
        public UsersController(UsersService svc) => _svc = svc;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            var (ok, error, data) = await _svc.RegisterAsync(dto);
            if (!ok) return BadRequest(new { error });
            return CreatedAtAction(nameof(GetById), new { id = data!.IdUser }, data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _svc.GetByIdAsync(id);

            if (user is null)
                return NotFound(new { ok = false, message = "Usuario no encontrado." });

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            // Corregir: usar _svc en vez de _service y declarar tipos explícitos
            (bool ok, string? error, int? idUser) = await _svc.LoginAsync(dto);

            if (!ok)
                return BadRequest(new { ok = false, error });

            return Ok(new
            {
                ok = true,
                message = "Login exitoso",
                idUser
            });
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