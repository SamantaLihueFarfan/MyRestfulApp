namespace MyRestfulApp.Application.Services.MercadoLibreService.Concrete
{
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
            return response;
        }

        public async Task<GetProductResponseDto?> GetProduct(string term)
        {
            var response = new GetProductResponseDto();
            Product? product;

            product = await _mercadoLibreRepository.GetProduct(term);

            response.Product = _mapper.Map<ProductDto>(product);
            return response;
        }
    }
}