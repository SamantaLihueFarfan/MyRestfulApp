namespace MyRestfulApp.Domain.Models.Entities.MercadoLibre
{
    public class Paging
    {
        /// <summary>
        /// Total
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// Resultados primarios
        /// </summary>
        public int primary_results { get; set; }

        /// <summary>
        /// Compensar
        /// </summary>
        public int offset { get; set; }

        /// <summary>
        /// Limite
        /// </summary>
        public int limit { get; set; }
    }
}
