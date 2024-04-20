using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.SaveUser;
using MyRestfulApp.Application.Services.MyRestfulAppService.Interface;

namespace MyRestfulApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyRestfulAppController : ControllerBase
    {
        private readonly IMyRestfulAppService _myRestfulAppService;

        public MyRestfulAppController(IMyRestfulAppService myRestfulAppService)
        {
            _myRestfulAppService = myRestfulAppService;
        }

        [HttpPost("SaveUser")]
        public async Task<SaveUserResponseDto> SaveStudent([FromBody] SaveUserRequestDto request)
        {
            return await _myRestfulAppService.SaveUser(request);
        }
    }
}
