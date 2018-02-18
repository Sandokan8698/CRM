using System.Threading.Tasks;
using Data.Abstract;

namespace Data.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields
        private readonly CRMContex _context;
        
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;
        private ITareaRepository _tareaRepository;
        private ITareaHistorialRepository _tareaHistorialRepository;
        private IClienteRepository _clienteRepository;
        private IContactoRepository _contactoRepository;
        private IProvinciaRepository _provinciaRepository;
        private ICiudadRepository _ciudadRepository;
        private IVendedorRepository _vendedorRepository;
        private ILineaNegocioRepository _lineaNegocioRepository;
        private IProductoRepository _productoRepository;
        private IEtapaRepository _etapaRepository;
        private ITipoGestionRepository _tipoGestionRepository;
        private ITomaDescicionRepository _tomaDescicionRepository;
        private ISenderoRepository _senderoRepository;
        private IReasignacionHistorialRepository _reasignacionHistorialRepository;
        #endregion

        #region Constructors
        public UnitOfWork()
        {
            _context = new CRMContex();
        }
        #endregion

        #region IUnitOfWork Members
        public IExternalLoginRepository ExternalLoginRepository
        {
            get { return _externalLoginRepository ?? (_externalLoginRepository = new ExternalLoginRepository(_context)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public ITareaRepository TareaRepository
        {
            get { return _tareaRepository ?? (_tareaRepository = new TareaRepository(_context)); }
        }

        public ITareaHistorialRepository TareaHistorialRepository
        {
            get { return _tareaHistorialRepository ?? (_tareaHistorialRepository = new TareaHistorialRepository(_context)); }
        }

        public IClienteRepository ClienteRepository
        {
            get { return _clienteRepository ?? (_clienteRepository = new ClienteRepository(_context)); }
        }


        public IContactoRepository ContactoRepository
        {
            get { return _contactoRepository ?? (_contactoRepository = new ContactoRepository(_context)); }
        }

        public IProvinciaRepository ProvinciaRepository
        {
            get { return _provinciaRepository ?? (_provinciaRepository = new ProvinciaRepository(_context)); }
        }

        public ICiudadRepository CiudadRepository                                                               
        {
            get { return _ciudadRepository ?? (_ciudadRepository = new CiudadRepository(_context)); }         
        }

        public IVendedorRepository VendedorRepository
        {
            get { return _vendedorRepository ?? (_vendedorRepository = new VendedorRepository(_context));  }
        }

        public ILineaNegocioRepository LineaNegocioRepository
        {
            get { return _lineaNegocioRepository ?? (_lineaNegocioRepository = new LineaNegocioRepository(_context)); }
        }

        public IProductoRepository ProductoRepository       
        {
            get { return _productoRepository ?? (_productoRepository = new ProductoRepository(_context)); }
        }

        public IEtapaRepository EtapaRepository 
        {
            get { return _etapaRepository ?? (_etapaRepository = new EtapaRepository(_context)); }
        }

        public ITipoGestionRepository TipoGestionRepository 
        {
            get { return _tipoGestionRepository ?? (_tipoGestionRepository = new TipoGestionRepository(_context)); }
        }

        public ITomaDescicionRepository TomaDescicionRepository
        {
            get { return _tomaDescicionRepository ?? (_tomaDescicionRepository = new TomaDescicionRepository(_context)); }
        }

        public ISenderoRepository SenderoRepository
        {
            get { return _senderoRepository ?? (_senderoRepository = new SenderoRepository(_context)); }
        }

        public IReasignacionHistorialRepository ReasignacionHistorialRepository         
        {
            get { return _reasignacionHistorialRepository ?? (_reasignacionHistorialRepository = new ReasignacionHistorialRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }
        #endregion
    }
}