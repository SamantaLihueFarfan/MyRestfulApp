
namespace MyRestfulApp.Application.Services.MyRestfulAppService.Interface
{
    using DTOs.MyRestfulAppDTOs.SaveUser;
    using DTOs.MyRestfulAppDTOs.UpdateUser;
    using DTOs.MyRestfulAppDTOs;

    public interface IMyRestfulAppService
    {
        public Task<SaveUserResponseDto> SaveUser(SaveUserRequestDto requestDto);
        public Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto requestDto);
        public Task<IEnumerable<UserDto>> GetUsers();
    }
}
