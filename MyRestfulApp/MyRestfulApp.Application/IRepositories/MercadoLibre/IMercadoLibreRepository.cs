namespace MyRestfulApp.Application.IRepositories.MercadoLibre
{
    using Domain.Models.Entities.MercadoLibre;

    public interface IMercadoLibreRepository
    {
        /// <summary>
        /// Consulta una lista de Paises
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Country>?> GetCountries();

        /// <summary>
        /// Consulta un Pais
        /// </summary>
        /// <returns></returns>
        public Task<Country?> GetCountry(string countryId);

        /// <summary>
        /// Consulta un Producto
        /// </summary>
        /// <returns></returns>
        public Task<Product?> GetProduct(string term);

        /// <summary>
        /// Consulta una Lista de Monedas
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Currency?>?> GetCurrencies();

        /// <summary>
        /// Consulta una Conversion de Moneda
        /// </summary>
        /// <returns></returns>
        public Task<CurrencyConversion?> GetCurrenciesConversions(string? from);
    }
}