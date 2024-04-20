namespace MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    public class SaveUserResponse : BaseResponse
    {
        public EntityEntry<User>? InsertedUser { get; set; }
    }
}
