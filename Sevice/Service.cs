using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Domain.Entities;

namespace Sevice
{
    public class Service: BaseService, IService
    {
       

        public bool UserHasRole(User user, Role role)
        {
            return user.Roles.Any(c => c.RoleId == role.RoleId);
        }

        public Service(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
        }
    }
}
