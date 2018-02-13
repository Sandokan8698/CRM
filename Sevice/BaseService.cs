using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Implementations;

namespace Sevice
{
    public abstract class BaseService
    {
        protected IUnitOfWork unitOfWork;

        public BaseService(IUnitOfWork UnitOfWork)
        {
            unitOfWork = UnitOfWork;
        }

        public BaseService()
        {
            unitOfWork = new UnitOfWork();
        }
    }
}
