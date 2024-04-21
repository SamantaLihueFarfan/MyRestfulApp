namespace MyRestfulApp.Domain.Models.Entities.MyRestfulApp.GetUsers
{
    public class GetUsersResponse : BaseResponse
    {
        public IEnumerable<User>? Users { get; set; }
    }
}