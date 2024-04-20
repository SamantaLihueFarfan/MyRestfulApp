namespace MyRestfulApp.Application.IRepositories.MyRestfulApp
{
    using Domain.Models.Entities.MyRestfulApp.SaveUser;
    public interface IMyRestfulAppRepository : IBaseInterfaceRepository
    {
        public Task<SaveUserResponse> SaveUser(SaveUserRequest? request);
    }
}
