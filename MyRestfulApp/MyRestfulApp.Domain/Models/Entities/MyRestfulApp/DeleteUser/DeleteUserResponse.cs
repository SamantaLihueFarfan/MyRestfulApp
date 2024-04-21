namespace MyRestfulApp.Domain.Models.Entities.MyRestfulApp.DeleteUser
{
    public class DeleteUserResponse : BaseResponse
    {
        public User? DeletedUser { get; set; }
    }
}