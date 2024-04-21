namespace MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.UpdateUser
{
    public class UpdateUserRequestDto
    {
        public int IdUser { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
