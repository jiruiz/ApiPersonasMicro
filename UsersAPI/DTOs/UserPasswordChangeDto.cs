namespace UsersAPI.DTOs
{
    // DTO usado para cambiar la contraseña de un usuario existente
    public class UserPasswordChangeDto
    {
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}