namespace MyRestfulApp.Application.IRepositories.MyRestfulApp
{
    using Domain.Models.Entities.MyRestfulApp.GetUser;
    using Domain.Models.Entities.MyRestfulApp.GetUsers;
    using Domain.Models.Entities.MyRestfulApp.DeleteUser;
    using Domain.Models.Entities.MyRestfulApp.SaveUser;
    using Domain.Models.Entities.MyRestfulApp.UpdateUser;

    public interface IMyRestfulAppRepository : IBaseInterfaceRepository
    {
        /// <summary>
        /// Guarda una entidad User en la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<SaveUserResponse> SaveUser(SaveUserRequest? request);

        /// <summary>
        /// Elimina una entidad User en la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<DeleteUserResponse> DeleteUser(DeleteUserRequest? request);

        /// <summary>
        /// Actualiza una entidad User en la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<UpdateUserResponse> UpdateUser(UpdateUserRequest? request);

        /// <summary>
        /// Obtiene una lista Users de la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<GetUsersResponse> GetUsers();

        /// <summary>
        /// Obtiene un User por su Id de la Bd MyRestfulApp 
        /// </summary>
        /// <returns></returns>
        public Task<GetUserResponse> GetUser(GetUserRequest? request);
    }
}