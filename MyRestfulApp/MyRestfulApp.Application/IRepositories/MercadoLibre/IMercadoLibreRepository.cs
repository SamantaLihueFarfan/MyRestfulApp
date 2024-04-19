namespace MyRestfulApp.Application.IRepositories.MercadoLibre
{
    using MyRestfulApp.Domain.Models.Entities.MercadoLibre;

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
    }
}