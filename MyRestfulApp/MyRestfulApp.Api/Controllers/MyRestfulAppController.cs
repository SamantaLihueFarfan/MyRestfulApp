namespace MyRestfulApp.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.DTOs.MyRestfulAppDTOs.DeleteUser;
    using Application.DTOs.MyRestfulAppDTOs.GetUser;
    using Application.DTOs.MyRestfulAppDTOs.GetUsers;
    using Application.DTOs.MyRestfulAppDTOs.SaveUser;
    using Application.DTOs.MyRestfulAppDTOs.UpdateUser;
    using Application.Services.MyRestfulAppService.Interface;

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

        [HttpDelete("DeleteUser")]
        public async Task<DeleteUserResponseDto> DeleteUser([FromQuery] DeleteUserRequestDto request)
        {
            return await _myRestfulAppService.DeleteUser(request);
        }

        [HttpGet("GetUsers")]
        public async Task<GetUsersResponseDto> GetUsers()
        {
            return await _myRestfulAppService.GetUsers();
        }

        [HttpGet("GetUser")]
        public async Task<GetUserResponseDto> GetUser([FromQuery] GetUserRequestDto request)
        {
            return await _myRestfulAppService.GetUser(request);
        }
    }
}