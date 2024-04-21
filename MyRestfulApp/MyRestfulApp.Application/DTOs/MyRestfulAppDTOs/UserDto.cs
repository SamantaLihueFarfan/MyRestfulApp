namespace MyRestfulApp.Application.DTOs.MyRestfulAppDTOs
{
    /// <summary>
    /// Entidad Dto Usuario
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; } = null!;

        /// <summary>
        /// Apellido
        /// </summary>
        public string Apellido { get; set; } = null!;

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; } = null!;
    }
}
