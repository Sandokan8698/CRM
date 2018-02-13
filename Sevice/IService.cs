using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Sevice
{
    public interface IService
    {
        bool UserHasRole(User user, Role role);

        List<Cliente> UserClientes(int userId);
    }
}
