namespace MyRestfulApp.Application.IRepositories
{
    using Microsoft.EntityFrameworkCore.Storage;
    public interface IBaseInterfaceRepository
    {
        /// <summary>
        /// Inicia una transacción en la base de datos
        /// </summary>
        /// <returns></returns>
        public Task<IDbContextTransaction> BeginTransaction();

        /// <summary>
        /// Confirma una transacción en la base de datos
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Task CommmitTransaction(IDbContextTransaction transaction);

        /// <summary>
        /// Deshace una transacción en la base de datos
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Task RollbackTransaction(IDbContextTransaction transaction);
    }
}
