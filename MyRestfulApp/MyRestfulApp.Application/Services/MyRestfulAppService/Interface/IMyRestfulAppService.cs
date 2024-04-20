
namespace MyRestfulApp.Application.Services.MyRestfulAppService.Interface
{
    using DTOs.MyRestfulAppDTOs.SaveUser;
    public interface IMyRestfulAppService
    {
        public Task<SaveUserResponseDto> SaveUser(SaveUserRequestDto requestDto);
    }
}
