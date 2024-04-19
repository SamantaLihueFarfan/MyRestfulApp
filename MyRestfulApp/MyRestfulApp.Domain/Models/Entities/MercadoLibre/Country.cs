namespace MyRestfulApp.Domain.Models.Entities.MercadoLibre
{
    /// <summary>
    /// Entidad Pais
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? id { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string? name { get; set; }

        /// <summary>
        /// Localidad
        /// </summary>
        public string? locale { get; set; }

        /// <summary>
        /// Id de Moneda
        /// </summary>
        public string? currency_id { get; set; }
        
        /// <summary>
        /// Separador decimal
        /// </summary>
        public string decimal_separator { get; set; }
        
        /// <summary>
        /// Separador de miles
        /// </summary>
        public string thousands_separator { get; set; }
        
        /// <summary>
        /// Zona Horaria
        /// </summary>
        public string time_zone { get; set; }
        
        /// <summary>
        /// Informacion Geografica
        /// </summary>
        public Geo_information geo_information { get; set; }
        
        /// <summary>
        /// Estados
        /// </summary>
        public States[] states { get; set; }
    }
}

