using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties
        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        ITareaRepository TareaRepository { get; }
        ITareaHistorialRepository TareaHistorialRepository { get; }
        IClienteRepository ClienteRepository { get; }
        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}
