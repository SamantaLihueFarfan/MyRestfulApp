namespace MyRestfulApp.Domain.Models.Entities.MercadoLibre
{
    /// <summary>
    /// Entidad Producto
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id del sitio
        /// </summary>
        public string? site_id { get; set; }

        /// <summary>
        /// Zona horaria predeterminada del pais
        /// </summary>
        public string? country_default_time_zone { get; set; }

        /// <summary>
        /// Consulta
        /// </summary>
        public string? query { get; set; }

        /// <summary>
        /// Paginacion
        /// </summary>
        public Paging paging { get; set; }

        /// <summary>
        /// Resultados
        /// </summary>
        public Results[] results { get; set; }

    }
}
