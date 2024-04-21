namespace MyRestfulApp.Application.Services.MercadoLibreService.Concrete
{
    using DTOs.MercadoLibreDTOs.GetCurrenciesConversion;
    using Domain.Models.Entities.MercadoLibre;
    using DTOs.MercadoLibreDTOs;
    using DTOs.MercadoLibreDTOs.GetCountry;
    using DTOs.MercadoLibreDTOs.GetProduct;
    using Interface;
    using AutoMapper;
    using IRepositories.MercadoLibre;

    public class MercadoLibreService : IMercadoLibreService
    {
        private readonly IMapper _mapper;
        private readonly IMercadoLibreRepository _mercadoLibreRepository;

        public MercadoLibreService(IMapper mapper, IMercadoLibreRepository mercadoLibreRepository)
        {
            _mapper = mapper;
            _mercadoLibreRepository = mercadoLibreRepository;
        }

        public async Task<GetCountryResponseDto?> GetCountry(string countryId)
        {
            var response = new GetCountryResponseDto();

            try
            {
                Country? country;

                if (countryId.Contains("AR"))
                {
                    country = await _mercadoLibreRepository.GetCountry(countryId);
                }
                else
                {
                    var countries = await _mercadoLibreRepository.GetCountries();
                    country = countries?.FirstOrDefault(c => c.id == countryId);
                }

                response.Country = _mapper.Map<CountryDto>(country);

                if (country is null)
                {
                    response.Message = "No se encontraron Paises";
                    response.Errors = new List<string>() { "No se encontraron Paises" };
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };
            }

            return response;
        }

        public async Task<GetCurrenciesConversionDto?> GetCurrenciesConversion()
        {
            var response = new GetCurrenciesConversionDto();

            try
            {
                // Obtener todas las monedas de forma asincrónica
                var currencies = await _mercadoLibreRepository.GetCurrencies();
                
                var currenciesMapped = _mapper.Map<List<CurrencyDto>>(currencies);

                // Obtener las conversiones de moneda en paralelo
                var currencyConversionTasks = currenciesMapped.Select(async currency =>
                {
                    var currencyConversion = await _mercadoLibreRepository.GetCurrenciesConversions(currency.Id);
                    return _mapper.Map<CurrencyConversionDto>(currencyConversion);
                });

                // Esperar todas las conversiones de moneda
                var currencyConversions = await Task.WhenAll(currencyConversionTasks);

                // Asignar las conversiones a las monedas
                for (var i = 0; i < currenciesMapped.Count; i++)
                {
                    currenciesMapped[i].ToDolar = currencyConversions[i];
                }

                response.currency_conversions = currenciesMapped;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };
            }

            return response;
        }

        public async Task<GetProductResponseDto?> GetProduct(string term)
        {
            var response = new GetProductResponseDto();

            try
            {
                var product = await _mercadoLibreRepository.GetProduct(term);

                response.Product = _mapper.Map<ProductDto>(product);

                if (product is null)
                {
                    response.Message = "No se encontró el Producto";
                    response.Errors = new List<string>() { string.Concat("No se encontró el producto con el nombre ", term) };
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };
            }

            return response;
        }
    }
}