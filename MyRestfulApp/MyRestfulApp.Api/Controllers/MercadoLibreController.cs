using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.Application.Services.MercadoLibreService.Interface;

namespace MyRestfulApp.Api.Controllers
{
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
            
            return Ok(await _mercadoLibreService.GetCountry(PAIS));
        }
    }
}