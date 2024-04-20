using MyRestfulApp.Domain.Models.Entities.MercadoLibre;

namespace MyRestfulApp.Application.DTOs.MercadoLibreDTOs
{
    public class ProductDto
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
        public PagingDto paging { get; set; }

        /// <summary>
        /// Resultados
        /// </summary>
        public ResultsDto[] results { get; set; }

    }
}
