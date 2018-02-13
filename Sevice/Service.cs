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

        public List<Cliente> UserClientes(int userId)
        {
            if (UserManagerService.Instance.UserInRole("Gerencia") ||
                UserManagerService.Instance.UserInRole("Administrador"))
            {
                return unitOfWork.ClienteRepository.GetAll();
            }

            return unitOfWork.ClienteRepository.Find(c => c.UserId == userId).ToList();
        }

    }
}
