namespace MyRestfulApp.Application.IRepositories.MyRestfulApp
{
    using Domain.Models.Entities.MyRestfulApp.SaveUser;
    using Domain.Models.Entities.MyRestfulApp.UpdateUser;
    using Domain.Models.Entities.MyRestfulApp;

    public interface IMyRestfulAppRepository : IBaseInterfaceRepository
    {
        public Task<SaveUserResponse> SaveUser(SaveUserRequest? request);
        public Task<UpdateUserResponse> UpdateUser(UpdateUserRequest? request);
        public Task<List<User>?> GetUsers();
    }
}
