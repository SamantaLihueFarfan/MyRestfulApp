namespace MyRestfulApp.Application.DTOs.MercadoLibreDTOs
{
    public class CurrencyDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// Simbolo
        /// </summary>
        public string? Symbol { get; set; }

        /// <summary>
        /// Descripcion
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// lugares decimales
        /// </summary>
        public int DecimalPlaces { get; set; }

        /// <summary>
        /// A Dolar
        /// </summary>
        public CurrencyConversionDto? ToDolar { get; set; }
    }
}