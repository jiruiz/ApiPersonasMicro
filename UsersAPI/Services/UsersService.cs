using Microsoft.EntityFrameworkCore;
using UsersAPI.Data;
using UsersAPI.DTOs;
using UsersAPI.Models;

namespace UsersAPI.Services
{
    public interface IUsersService
    {
        Task<(bool ok, string? error, UserReadDto? data)> RegisterAsync(UserRegisterDto dto);
        Task<(bool ok, string? error, int? idUser)> LoginAsync(UserLoginDto dto);
        Task<(bool ok, string? error, UserReadDto? data)> UpdateAsync(int id, UserUpdateDto dto);
        Task<(bool ok, string? error)> ChangePasswordAsync(int id, UserPasswordChangeDto dto);
    }

    public class UsersService : IUsersService
    {
        private readonly UsersContext _ctx;

        public UsersService(UsersContext ctx) => _ctx = ctx;

        // 🔹 1. REGISTRO DE USUARIO
        public async Task<(bool, string?, UserReadDto?)> RegisterAsync(UserRegisterDto dto)
        {
            // Validaciones básicas. Obligatoriedad de campos
            if (string.IsNullOrWhiteSpace(dto.UserName) ||
                string.IsNullOrWhiteSpace(dto.Email) ||
                string.IsNullOrWhiteSpace(dto.UserLastName) ||
                string.IsNullOrWhiteSpace(dto.Password))
                return (false, "Campos obligatorios faltantes.", null);
           
            //Standar de seguridad - 8 caracteres mínimo
            if (dto.Password.Length < 8)
                return (false, "La contraseña debe tener al menos 8 caracteres.", null);

            var userName = dto.UserName.Trim();
            var email = dto.Email.Trim().ToLowerInvariant();

            // Verifica si ya existe ese email o username
            var exists = await _ctx.Users.AnyAsync(u =>
                u.Email.ToLower() == email);

            if (exists)
                return (false, "El Email ya se encuentra registrado.", null);

            // Hash de la contraseña. Se encripta la password
            var hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var entity = new User
            {
                UserName = userName,
                Email = email,
                UserLastName = dto.UserLastName.Trim(),
                UserPassword = hash,
                InsertDate = DateTime.UtcNow,
                PasswordModifyDate = DateTime.UtcNow,
                Active = true
            };

            _ctx.Users.Add(entity);
            await _ctx.SaveChangesAsync();

            // Devuelve DTO limpio sin contraseña
            var read = new UserReadDto
            {
                IdUser = entity.IdUser,
                UserName = entity.UserName,
                Email = entity.Email,
                UserLastName = entity.UserLastName,
                Active = entity.Active,
                InsertDateUtc = entity.InsertDate.ToString("o"),
                ModifyDateUtc = entity.ModifyDate?.ToString("o"),
                PasswordModifyDateUtc = entity.PasswordModifyDate?.ToString("o")
            };

            return (true, null, read);
        }

        // 🔹 2. LOGIN POR EMAIL
        public async Task<(bool ok, string? error, int? idUser)> LoginAsync(UserLoginDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password))
                return (false, "Email y contraseña son obligatorios.", null);

            var user = await _ctx.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email.ToLower() == dto.Email.ToLower());

            if (user is null)
                return (false, "Email o contraseña inválidos.", null);

            var ok = BCrypt.Net.BCrypt.Verify(dto.Password, user.UserPassword);
            if (!ok)
                return (false, "Email o contraseña inválidos.", null);

            if (!user.Active)
                return (false, "El usuario está inactivo.", null);

            // ✅ Si llegás hasta acá, el login es exitoso
            return (true, null, user.IdUser);
        }

        // 🔹 3. ACTUALIZACIÓN DE DATOS DE USUARIO
        public async Task<(bool, string?, UserReadDto?)> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _ctx.Users.FindAsync(id);
            if (user is null)
                return (false, "Usuario no encontrado.", null);

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var email = dto.Email.Trim().ToLowerInvariant();
                var emailTaken = await _ctx.Users.AnyAsync(u => u.IdUser != id && u.Email.ToLower() == email);
                if (emailTaken)
                    return (false, "El email ya está en uso.", null);
                user.Email = email;
            }

            if (!string.IsNullOrWhiteSpace(dto.UserName))
                user.UserName = dto.UserName.Trim();

            if (!string.IsNullOrWhiteSpace(dto.UserLastName))
                user.UserLastName = dto.UserLastName.Trim();

            if (dto.Active.HasValue)
                user.Active = dto.Active.Value;

            user.ModifyDate = DateTime.UtcNow;
            await _ctx.SaveChangesAsync();

            var read = new UserReadDto
            {
                IdUser = user.IdUser,
                UserName = user.UserName,
                Email = user.Email,
                UserLastName = user.UserLastName,
                Active = user.Active,
                InsertDateUtc = user.InsertDate.ToString("o"),
                ModifyDateUtc = user.ModifyDate?.ToString("o"),
                PasswordModifyDateUtc = user.PasswordModifyDate?.ToString("o")
            };

            return (true, null, read);
        }

        // 🔹 4. CAMBIO DE CONTRASEÑA
        public async Task<(bool, string?)> ChangePasswordAsync(int id, UserPasswordChangeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NewPassword))
                return (false, "La nueva contraseña es obligatoria.");

            if (dto.NewPassword != dto.ConfirmNewPassword)
                return (false, "Las contraseñas no coinciden.");

            if (dto.NewPassword.Length < 8)
                return (false, "La contraseña debe tener al menos 8 caracteres.");

            var user = await _ctx.Users.FindAsync(id);
            if (user is null)
                return (false, "Usuario no encontrado.");

            user.UserPassword = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.PasswordModifyDate = DateTime.UtcNow;
            user.ModifyDate = DateTime.UtcNow;

            await _ctx.SaveChangesAsync();
            return (true, null);
        }

        // 🔹 5. DEVOLUCIÓN DE DATOS DE USUARIO POR ID

        public async Task<UserReadDto?> GetByIdAsync(int id)
        {
            var user = await _ctx.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.IdUser == id);

            if (user is null)
                return null;

            return new UserReadDto
            {
                IdUser = user.IdUser,
                UserName = user.UserName,
                UserLastName = user.UserLastName,
                Email = user.Email,
                Active = user.Active,
                InsertDateUtc = user.InsertDate.ToString("o"),
                ModifyDateUtc = user.ModifyDate?.ToString("o"),
                PasswordModifyDateUtc = user.PasswordModifyDate?.ToString("o")
            };
        }

    }
}