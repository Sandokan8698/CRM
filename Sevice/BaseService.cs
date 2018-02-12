using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;

namespace Sevice
{
    public abstract class BaseService
    {
        private IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }
    }
}
