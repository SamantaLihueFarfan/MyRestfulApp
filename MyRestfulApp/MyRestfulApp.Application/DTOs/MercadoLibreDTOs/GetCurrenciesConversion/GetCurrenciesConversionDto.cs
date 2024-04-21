namespace MyRestfulApp.Application.DTOs.MercadoLibreDTOs.GetCurrenciesConversion
{
    public class GetCurrenciesConversionDto : BaseResponseDto
    {
        /// <summary>
        /// Lista de Monedas
        /// </summary>
        public IEnumerable<CurrencyDto> currency_conversions { get; set; }
    }
}

