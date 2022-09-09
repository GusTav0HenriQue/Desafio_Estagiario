namespace Dominio.DTOs.UserDtos
{
    public class UpdateUserDto
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }
    }
}
