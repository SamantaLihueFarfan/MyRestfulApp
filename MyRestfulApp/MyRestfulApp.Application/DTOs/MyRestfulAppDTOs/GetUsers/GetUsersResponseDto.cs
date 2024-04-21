namespace MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.GetUsers
{
    using Domain.Models;

    public class GetUsersResponseDto : BaseResponse
    {
        public IEnumerable<UserDto?>? Users { get; set; }
    }
}