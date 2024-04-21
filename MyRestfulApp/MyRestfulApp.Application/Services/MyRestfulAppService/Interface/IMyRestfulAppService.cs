
using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.GetUser;
using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.GetUsers;

namespace MyRestfulApp.Application.Services.MyRestfulAppService.Interface
{
    using DTOs.MyRestfulAppDTOs.DeleteUser;
    using DTOs.MyRestfulAppDTOs.SaveUser;
    using DTOs.MyRestfulAppDTOs.UpdateUser;
    using DTOs.MyRestfulAppDTOs;

    public interface IMyRestfulAppService
    {
        /// <summary>
        /// Guarda una entidad User en la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<SaveUserResponseDto> SaveUser(SaveUserRequestDto requestDto);
        
        /// <summary>
        /// Actualiza una entidad User en la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto requestDto);
        
        /// <summary>
        /// Obtiene una lista Users de la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<GetUsersResponseDto> GetUsers();
        
        /// <summary>
        /// Elimina una entidad User en la Bd MyRestfulApp
        /// </summary>
        /// <returns></returns>
        public Task<DeleteUserResponseDto> DeleteUser(DeleteUserRequestDto? requestDto);

        /// <summary>
        /// Obtiene un User por su Id de la Bd MyRestfulApp 
        /// </summary>
        /// <returns></returns>
        public Task<GetUserResponseDto> GetUser(GetUserRequestDto? requestDto);
    }
}
