namespace MyRestfulApp.Domain.Models.Entities.MercadoLibre
{
    /// <summary>
    /// Entidad Resultado
    /// </summary>
    public class Results
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// Titulo
        /// </summary>
        public string? title { get; set; }

        /// <summary>
        /// Enlace permanente
        /// </summary>
        public string? permalink { get; set; }

        /// <summary>
        /// Id del sitio
        /// </summary>
        public string? site_id { get; set; }

        /// <summary>
        /// Precio
        /// </summary>
        public double price { get; set; }

        /// <summary>
        /// Vendedor
        /// </summary>
        public Seller seller { get; set; }

    }
}
