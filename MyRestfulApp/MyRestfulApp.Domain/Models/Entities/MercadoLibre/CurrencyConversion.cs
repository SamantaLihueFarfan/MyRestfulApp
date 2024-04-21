namespace MyRestfulApp.Domain.Models.Entities.MercadoLibre
{
    /// <summary>
    /// Entidad Conversion de Moneda
    /// </summary>
    public class CurrencyConversion
    {
        /// <summary>
        /// Base de Moneda
        /// </summary>
        public string currency_base { get; set; }
        /// <summary>
        /// Cotización de Moneda
        /// </summary>
        public string currency_quote { get; set; }
        /// <summary>
        /// Relación
        /// </summary>
        public double ratio { get; set; }
        /// <summary>
        /// Tasa
        /// </summary>
        public double rate { get; set; }
        /// <summary>
        /// Tasa de Inversion
        /// </summary>
        public double inv_rate { get; set; }
        /// <summary>
        /// Fecha de Creacion
        /// </summary>
        public string creation_date { get; set; }
        /// <summary>
        /// Valido Hasta
        /// </summary>
        public string valid_until { get; set; }
    }
}

