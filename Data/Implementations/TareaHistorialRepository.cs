using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Domain.Entities;

namespace Data.Implementations
{
    public class TareaHistorialRepository: Repository<TareaHistorial>, ITareaHistorialRepository
    {
        internal TareaHistorialRepository(CRMContex context) : base(context)
        {
        }
    }
}
