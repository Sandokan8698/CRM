using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Domain.Entities;

namespace Data.Implementations
{
    public class CiudadRepository: Repository<Ciudad>, ICiudadRepository
    {
        internal CiudadRepository(CRMContex context) : base(context)
        {
        }
    }
}
