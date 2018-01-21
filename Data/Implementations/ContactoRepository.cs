using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Implementations
{
    public class ContactoRepository: Repository<Contacto>, IContactoRepository
    {
        internal ContactoRepository(CRMContex context) : base(context)
        {
        }
    }
}
