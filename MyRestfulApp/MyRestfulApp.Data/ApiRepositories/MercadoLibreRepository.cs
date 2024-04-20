namespace MyRestfulApp.Data.ApiRepositories
{
    using Domain.Models.Entities.MercadoLibre;
    using Application.IRepositories.MercadoLibre;
    using System.Text.Json; // revisar para que sirve
    using RestSharp; // revisar para que sirve
    using Microsoft.Extensions.Options;
    using Settings;

    public class MercadoLibreRepository : IMercadoLibreRepository
    {
        private readonly Settings? _settings;

        public MercadoLibreRepository(IOptions<Settings>? options)
        {
            _settings = options?.Value; //revisar para que sirve
        }

        public async Task<IEnumerable<Country>?> GetCountries()
        {
            if (_settings is null || string.IsNullOrWhiteSpace(_settings.ApiMercadoLibre?.ApiBaseUrl)
                                  || string.IsNullOrWhiteSpace(_settings.ApiMercadoLibre?.Countries))
            {
                return null;
            }

            var client = new RestClient(_settings.ApiMercadoLibre.ApiBaseUrl);
            var restRequest = new RestRequest(_settings.ApiMercadoLibre?.Countries);

            var response = await client.ExecuteAsync(restRequest);

            return response.Content == null ? null : JsonSerializer.Deserialize<IEnumerable<Country>>(response.Content);
        }

        public async Task<Country?> GetCountry(string countryId)
        {
            if (_settings is null || string.IsNullOrWhiteSpace(_settings.ApiMercadoLibre?.ApiBaseUrl)
                                  || string.IsNullOrWhiteSpace(_settings.ApiMercadoLibre?.Country))
            {
                return null;
            }

            var client = new RestClient(_settings.ApiMercadoLibre.ApiBaseUrl);
            var restRequest = new RestRequest(string.Concat(_settings.ApiMercadoLibre?.Country, countryId));

            var response = await client.ExecuteAsync(restRequest);

            return response.Content == null ? null : JsonSerializer.Deserialize<Country>(response.Content);
        }

        public async Task<Product?> GetProduct(string term)
        {
            if (_settings is null || string.IsNullOrWhiteSpace(_settings.ApiMercadoLibre?.ApiBaseUrl)
                                  || string.IsNullOrWhiteSpace(_settings.ApiMercadoLibre?.Product))
            {
                return null;
            }

            var client = new RestClient(_settings.ApiMercadoLibre.ApiBaseUrl);
            var restRequest = new RestRequest(_settings.ApiMercadoLibre?.Product);
            restRequest.AddHeader("search", term);

            var response = await client.ExecuteAsync(restRequest);

            return response.Content == null ? null : JsonSerializer.Deserialize<Product>(response.Content);
        }
    }
}