namespace MyRestfulApp.Application.Services.MercadoLibreService.Interface
{
    using DTOs.MercadoLibreDTOs.GetCountry;

    public interface IMercadoLibreService
    {
        /// <summary>
        /// Consulta un Pais
        /// </summary>
        /// <returns></returns>
        public Task<GetCountryResponseDto?> GetCountry(string countryId);
    }
}