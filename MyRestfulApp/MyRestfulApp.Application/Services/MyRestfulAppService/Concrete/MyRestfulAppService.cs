
namespace MyRestfulApp.Application.Services.MyRestfulAppService.Concrete
{
    using AutoMapper;
    using DTOs.MyRestfulAppDTOs.SaveUser;
    using IRepositories.MyRestfulApp;
    using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs;
    using MyRestfulApp.Application.DTOs.MyRestfulAppDTOs.UpdateUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.UpdateUser;
    using Services.MyRestfulAppService.Interface;
    public class MyRestfulAppService : IMyRestfulAppService
    {
        private readonly IMapper _mapper;
        private readonly IMyRestfulAppRepository _myRestfulAppRepository;
        private const string _emptyRequestErrorMessage = "El request es null";

        public MyRestfulAppService(IMapper mapper, IMyRestfulAppRepository myRestfulAppRepository)
        {
            _mapper = mapper;
            _myRestfulAppRepository = myRestfulAppRepository;
        }
        public async Task<SaveUserResponseDto> SaveUser(SaveUserRequestDto requestDto)
        {
            var response = new SaveUserResponseDto();
            if (requestDto is null || string.IsNullOrEmpty(requestDto.Nombre) || string.IsNullOrEmpty(requestDto.Apellido)
                || string.IsNullOrEmpty(requestDto.Email) || string.IsNullOrEmpty(requestDto.Password)) 
            { 
                response.Message = _emptyRequestErrorMessage;
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

        public async Task<UpdateUserResponseDto> UpdateUser(UpdateUserRequestDto? requestDto)
        {
            var response = new UpdateUserResponseDto();

            if (requestDto is null || requestDto.IdUser == 0 || string.IsNullOrEmpty(requestDto.Nombre) ||
                string.IsNullOrEmpty(requestDto.Apellido) || string.IsNullOrEmpty(requestDto.Email) || string.IsNullOrEmpty(requestDto.Password))
            {
                response.Message = _emptyRequestErrorMessage;
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

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var result = await _myRestfulAppRepository.GetUsers();
            var response = _mapper.Map<IEnumerable<UserDto>>(result);

            return response;
        }
    }
}
