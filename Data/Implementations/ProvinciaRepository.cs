using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Domain.Entities;

namespace Data.Implementations
{
    public class ProvinciaRepository: Repository<Provincia>, IProvinciaRepository
    {
        internal ProvinciaRepository(CRMContex context) : base(context)
        {
        }
    }
}
