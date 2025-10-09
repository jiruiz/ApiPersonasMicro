namespace UsersAPI.DTOs
{
    // DTO usado para actualizar datos de usuario
    public class UserUpdateDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? UserLastName { get; set; }
        public bool? Active { get; set; }
    }
}