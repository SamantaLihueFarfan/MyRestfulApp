namespace MyRestfulApp.Application.Services.MercadoLibreService.Interface
{
    using DTOs.MercadoLibreDTOs.GetCurrenciesConversion;
    using DTOs.MercadoLibreDTOs.GetCountry;
    using DTOs.MercadoLibreDTOs.GetProduct;

    public interface IMercadoLibreService
    {
        /// <summary>
        /// Consulta un Pais
        /// </summary>
        /// <returns></returns>
        public Task<GetCountryResponseDto?> GetCountry(string countryId);

        public Task<GetProductResponseDto?> GetProduct(string term);

        /// <summary>
        /// Consulta una Lista de Monedas con su conversion a Dolar
        /// </summary>
        /// <returns></returns>
        public Task<GetCurrenciesConversionDto?> GetCurrenciesConversion();
    }
}