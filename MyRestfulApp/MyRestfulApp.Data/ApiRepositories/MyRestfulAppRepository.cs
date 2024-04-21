using Microsoft.EntityFrameworkCore;
using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.DeleteUser;
using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.GetUser;
using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.GetUsers;

namespace MyRestfulApp.Data.ApiRepositories
{
    using Domain.Models.Contexts;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;
    using MyRestfulApp.Application.IRepositories.MyRestfulApp;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.UpdateUser;

    public class MyRestfulAppRepository : IMyRestfulAppRepository
    {
        private const string _emptyRequestErrorMessage = "El request es null";
        private const string MessageDeleteUser = "No se encontro el usuario a Eliminar";
        private readonly MyRestfulAppDB _context;

        public MyRestfulAppRepository(MyRestfulAppDB context)
        {
            _context = context;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task CommmitTransaction(IDbContextTransaction? transaction)
        {
            if (transaction is not null)
            {
                await transaction.CommitAsync();
            }
        }

        public async Task RollbackTransaction(IDbContextTransaction? transaction)
        {
            if (transaction is not null)
            {
                await transaction.RollbackAsync();
            }
        }

        public async Task<SaveUserResponse> SaveUser(SaveUserRequest? request)
        {
            var response = new SaveUserResponse();

            try
            {
                if (request is null || string.IsNullOrEmpty(request.Nombre) || string.IsNullOrEmpty(request.Apellido)
                    || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    response.Message = _emptyRequestErrorMessage;
                    response.Errors = new List<string>() { string.Empty };

                    return response;
                }

                var user = new User()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Email = request.Email,
                    Password = request.Password
                };

                response.InsertedUser = await _context.Users.AddAsync(user);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Errors = new List<string>() { ex.Message };
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    response.Errors.Add(ex.Message);
                }
            }

            return response;
        }

        public async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest? request)
        {
            var response = new DeleteUserResponse();

            try
            {
                if (request?.Id is null)
                {
                    response.Message = _emptyRequestErrorMessage;
                    response.Errors = new List<string>() { string.Empty };

                    return response;
                }

                var deleteUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

                if (deleteUser is null)
                {
                    response.Message = MessageDeleteUser;
                    response.Errors = new List<string>() { string.Empty };
                }
                else
                {
                    response.DeletedUser = deleteUser;
                    _context.Users.Remove(deleteUser);

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                response.Errors = new List<string>() { ex.Message };
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    response.Errors.Add(ex.Message);
                }
            }

            return response;
        }

        public async Task<UpdateUserResponse> UpdateUser(UpdateUserRequest? request)
        {
            var response = new UpdateUserResponse();

            try
            {
                if (request is null || request.IdUser == 0 || string.IsNullOrEmpty(request.Nombre) ||
                    string.IsNullOrEmpty(request.Apellido) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
                {
                    response.Message = _emptyRequestErrorMessage;
                    response.Errors = new List<string>() { string.Empty };

                    return response;
                }

                var existUser = await _context.Users.FirstOrDefaultAsync(s => s.Id == request.IdUser);

                if (existUser is not null)
                {
                    existUser.Nombre = request.Nombre;
                    existUser.Apellido = request.Apellido;
                    existUser.Email = request.Email;
                    existUser.Password = request.Password;
                }

                response.UpdateUser = existUser;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Errors = new List<string>() { ex.Message };
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    response.Errors.Add(ex.Message);
                }
            }

            return response;
        }

        public async Task<GetUsersResponse> GetUsers()
        {
            var response = new GetUsersResponse();

            try
            {
                response.Users = await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                response.Errors = new List<string>() { ex.Message };
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    response.Errors.Add(ex.Message);
                }
            }
            
            return response;
        }
        
        public async Task<GetUserResponse> GetUser(GetUserRequest? request)
        {
            var response = new GetUserResponse();

            try
            {
                if (request?.Id is null )
                {
                    response.Message = _emptyRequestErrorMessage;
                    response.Errors = new List<string>() { string.Empty };

                    return response;
                }
                
                response.User = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);
            }
            catch (Exception ex)
            {
                response.Errors = new List<string>() { ex.Message };
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    response.Errors.Add(ex.Message);
                }
            }
            
            return response;
        }
    }
}