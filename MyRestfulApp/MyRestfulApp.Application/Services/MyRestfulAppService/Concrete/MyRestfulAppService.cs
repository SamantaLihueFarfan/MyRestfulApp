using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.GetUser;
using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.GetUsers;
using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.GetUser;

namespace MyRestfulApp.Application.Services.MyRestfulAppService.Concrete
{
    using DTOs.MyRestfulAppDTOs.DeleteUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.DeleteUser;
    using AutoMapper;
    using DTOs.MyRestfulAppDTOs.SaveUser;
    using IRepositories.MyRestfulApp;
    using DTOs.MyRestfulAppDTOs;
    using DTOs.MyRestfulAppDTOs.UpdateUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.UpdateUser;
    using Interface;

    public class MyRestfulAppService : IMyRestfulAppService
    {
        private readonly IMapper _mapper;
        private readonly IMyRestfulAppRepository _myRestfulAppRepository;
        private const string EmptyRequestErrorMessage = "El request es null";

        public MyRestfulAppService(IMapper mapper, IMyRestfulAppRepository myRestfulAppRepository)
        {
            _mapper = mapper;
            _myRestfulAppRepository = myRestfulAppRepository;
        }

        public async Task<SaveUserResponseDto> SaveUser(SaveUserRequestDto? requestDto)
        {
            var response = new SaveUserResponseDto();

            if (requestDto is null || string.IsNullOrEmpty(requestDto.Nombre) || string.IsNullOrEmpty(requestDto.Apellido)
                || string.IsNullOrEmpty(requestDto.Email) || string.IsNullOrEmpty(requestDto.Password))
            {
                response.Message = EmptyRequestErrorMessage;
                response.Errors = new List<string>() { string.Empty };
                return response;
            }

            var transaction = await _myRestfulAppRepository.BeginTransaction();

            try
            {
                var mapperUser = _mapper.Map<SaveUserRequest>(requestDto);

                var saveUserResponse = await _myRestfulAppRepository.SaveUser(mapperUser);

                if (!saveUserResponse.IsValid)
                {
                    response.Message = saveUserResponse.Message;
                    response.Errors = saveUserResponse.Errors;

                    await _myRestfulAppRepository.RollbackTransaction(transaction);
                    return response;
                }

                await _myRestfulAppRepository.CommmitTransaction(transaction);

                response.Data = new SaveUserResponseDataDto() { IsSaveCorrect = true };
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };

                await _myRestfulAppRepository.RollbackTransaction(transaction);
            }

            return response;
        }

        public async Task<DeleteUserResponseDto> DeleteUser(DeleteUserRequestDto? requestDto)
        {
            var response = new DeleteUserResponseDto();

            if (requestDto?.Id is null)
            {
                response.Message = EmptyRequestErrorMessage;
                response.Errors = new List<string>() { string.Empty };
                return response;
            }

            var transaction = await _myRestfulAppRepository.BeginTransaction();

            try
            {
                var mapperUser = _mapper.Map<DeleteUserRequest>(requestDto);

                var deleteUserResponse = await _myRestfulAppRepository.DeleteUser(mapperUser);

                if (!deleteUserResponse.IsValid)
                {
                    response.Message = deleteUserResponse.Message;
                    response.Errors = deleteUserResponse.Errors;

                    await _myRestfulAppRepository.RollbackTransaction(transaction);
                    return response;
                }

                await _myRestfulAppRepository.CommmitTransaction(transaction);

                response.Data = new DeleteUserResponseDataDto() { IsDeleteCorrect = true };
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };

                await _myRestfulAppRepository.RollbackTransaction(transaction);
            }

            return response;
        }

        public async Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto? requestDto)
        {
            var response = new UpdateUserResponseDto();

            if (requestDto is null || requestDto.IdUser == 0 || string.IsNullOrEmpty(requestDto.Nombre) ||
                string.IsNullOrEmpty(requestDto.Apellido) || string.IsNullOrEmpty(requestDto.Email) || string.IsNullOrEmpty(requestDto.Password))
            {
                response.Message = EmptyRequestErrorMessage;
                response.Errors = new List<string>() { string.Empty };

                return response;
            }

            var transaction = await _myRestfulAppRepository.BeginTransaction();

            try
            {
                var mapperUser = _mapper.Map<UpdateUserRequest>(requestDto);

                var updateUserResponse = await _myRestfulAppRepository.UpdateUser(mapperUser);

                if (!updateUserResponse.IsValid)
                {
                    response.Message = updateUserResponse.Message;
                    response.Errors = updateUserResponse.Errors;

                    await _myRestfulAppRepository.RollbackTransaction(transaction);
                    return response;
                }

                await _myRestfulAppRepository.CommmitTransaction(transaction);

                response.Data = new UpdateUserResponseDataDto() { IsUpdateCorrect = true };
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };

                await _myRestfulAppRepository.RollbackTransaction(transaction);
            }

            return response;
        }

        public async Task<GetUsersResponseDto> GetUsers()
        {
            var response = new GetUsersResponseDto();

            try
            {
                var result = await _myRestfulAppRepository.GetUsers();
                response.Users = _mapper.Map<IEnumerable<UserDto>>(result.Users);

                if (!result.IsValid)
                {
                    response.Message = result.Message;
                    response.Errors = result.Errors;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };
            }

            return response;
        }

        public async Task<GetUserResponseDto> GetUser(GetUserRequestDto? requestDto)
        {
            var response = new GetUserResponseDto();

            try
            {
                var mapperUser = _mapper.Map<GetUserRequest>(requestDto);

                var result = await _myRestfulAppRepository.GetUser(mapperUser);

                response.User = _mapper.Map<UserDto>(result.User);

                if (!result.IsValid)
                {
                    response.Message = result.Message;
                    response.Errors = result.Errors;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Errors = new List<string>() { string.Empty };
            }

            return response;
        }
    }
}