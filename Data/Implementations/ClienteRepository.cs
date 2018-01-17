using Data.Abstract;
using Domain.Entities;

namespace Data.Implementations
{
    internal class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        internal ClienteRepository(CRMContex context) : base(context)
        {
        }
    }
}