using System;
using System.Threading;
using System.Threading.Tasks;
using Data.Implementations;

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
        IContactoRepository ContactoRepository { get; }
        IProvinciaRepository ProvinciaRepository { get; }
        ICiudadRepository CiudadRepository { get; }
        IVendedorRepository VendedorRepository { get; }
        ILineaNegocioRepository LineaNegocioRepository { get; }
        IProductoRepository ProductoRepository { get; }
        IEtapaRepository EtapaRepository { get; }
        ITipoGestionRepository TipoGestionRepository { get; }
        ITomaDescicionRepository TomaDescicionRepository { get; }
        ISenderoRepository SenderoRepository { get; }
        #endregion

        #region Methods
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        #endregion
    }
}
