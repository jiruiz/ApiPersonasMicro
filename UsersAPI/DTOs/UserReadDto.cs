namespace UsersAPI.DTOs
{
    // DTO usado para devolver información de usuario sin exponer la contraseña
    public class UserReadDto
    {   
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserLastName { get; set; }
        public bool Active { get; set; }
        public string InsertDateUtc { get; set; }
        public string? ModifyDateUtc { get; set; }
        public string? PasswordModifyDateUtc { get; set; }
    }
}