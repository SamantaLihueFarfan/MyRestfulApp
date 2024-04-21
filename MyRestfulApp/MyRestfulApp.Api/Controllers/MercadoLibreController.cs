namespace MyRestfulApp.Api.Controllers
{
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using Application.Services.MercadoLibreService.Interface;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class MercadoLibreController : ControllerBase
    {
        private static readonly string[] CountriesUnauthorized = ["BR", "CO"];
        private const string ResponseUnauthorized = "error 401 unauthorized de http";

        private readonly IMercadoLibreService _mercadoLibreService;

        public MercadoLibreController(IMercadoLibreService mercadoLibreService)
        {
            _mercadoLibreService = mercadoLibreService;
        }

        [HttpGet("PAISES/{PAIS}")]
        public async Task<ObjectResult> GetCountry(string PAIS)
        {
            if (CountriesUnauthorized.Contains(PAIS.ToUpper()))
            {
                return Unauthorized(ResponseUnauthorized);
            }

            return Ok(await _mercadoLibreService.GetCountry(PAIS.ToUpper()));
        }

        [HttpGet("busqueda/{TERMINO}")]
        public async Task<ObjectResult> GetProduct(string TERMINO)
        {
            return Ok(await _mercadoLibreService.GetProduct(TERMINO.ToLower()));
        }

        [HttpGet("DownloaderCurrenciesConversionJSON")]
        public async Task<IActionResult> DownloaderCurrenciesConversionJson()
        {
            var result = await _mercadoLibreService.GetCurrenciesConversion();
            
            if (!result.IsValid)
            {
                return Conflict(result);
            }
            
            var jsonContentRequestString = JsonConvert.SerializeObject(result);

            return File(Encoding.UTF8.GetBytes(jsonContentRequestString), "application/json", "CurrenciesConversion.json");
        }

        [HttpGet("DownloaderCurrenciesConversionCSV")]
        public async Task<IActionResult> DownloaderCurrenciesConversionCsv()
        {
            var result = await _mercadoLibreService.GetCurrenciesConversion();

            if (result is null || !result.IsValid)
            {
                return Conflict(result);
            }
            
            var sb = new StringBuilder();
            sb.Append("Descripcion, Conversion de Moneda");
            sb.Append("\r\n");
            
            foreach (var currencyConversion in result.currency_conversions)
            {
                sb.Append(string.Concat(currencyConversion.Description, ",", currencyConversion.ToDolar?.ratio));
                sb.Append("\r\n");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "CurrenciesConversion.csv");
        }
    }
}