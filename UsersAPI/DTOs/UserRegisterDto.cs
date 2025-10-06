public class UserRegisterDto
{
    public string? UserName { get; set; } // opcional
    public string UserLastName { get; set; }
    public string Email { get; set; } // login principal
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}