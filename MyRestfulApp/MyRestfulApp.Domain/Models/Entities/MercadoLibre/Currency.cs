namespace MyRestfulApp.Domain.Models.Entities.MercadoLibre
{
    /// <summary>
    /// Entidad Moneda
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Simbolo
        /// </summary>
        public string symbol { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// lugares decimales
        /// </summary>
        public int decimal_places { get; set; }
    }
}