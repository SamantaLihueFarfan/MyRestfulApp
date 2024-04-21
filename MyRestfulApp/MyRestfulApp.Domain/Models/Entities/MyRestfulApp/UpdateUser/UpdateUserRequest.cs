namespace MyRestfulApp.Domain.Models.Entities.MyRestfulApp.UpdateUser
{
    public class UpdateUserRequest
    {
        public int IdUser { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
