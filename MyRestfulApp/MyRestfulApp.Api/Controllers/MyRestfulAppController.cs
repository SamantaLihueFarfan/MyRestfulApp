using Microsoft.AspNetCore.Mvc;
using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs;
using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.SaveUser;
using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.UpdateUser;
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
        public async Task<SaveUserResponseDto> SaveUser([FromBody] SaveUserRequestDto request)
        {
            return await _myRestfulAppService.SaveUser(request);
        }

        [HttpPut("UpdateUser")]
        public async Task<UpdateUserResponseDto> UpdateUser([FromBody] UpdateUserRequestDto request)
        {
            return await _myRestfulAppService.UpdateUser(request);
        }

        [HttpGet("GetUsers")]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _myRestfulAppService.GetUsers();
        }
    }
}
