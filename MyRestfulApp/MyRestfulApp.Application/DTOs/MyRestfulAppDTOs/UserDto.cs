namespace MyRestfulApp.Application.DTOs.MyRestfulAppDTOs
{
    public class UserDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
