
namespace MyRestfulApp.Data.ApiRepositories
{
    using Domain.Models.Contexts;
    using Microsoft.EntityFrameworkCore.Storage;
    using MyRestfulApp.Application.IRepositories.MyRestfulApp;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp;
    using MyRestfulApp.Domain.Models.Entities.MyRestfulApp.SaveUser;

    public class MyRestfulAppRepository : IMyRestfulAppRepository
    {
        private const string _emptyRequestErrorMessage = "El request es null";
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
    }
}
