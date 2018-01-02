using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementations;
using Domain.Entities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CRMContex();

            var user = context.UserDbSet.FirstOrDefault(u => u.UserId == 1);

            var vendedor = new Vendedor();
            vendedor.PefilId = 1;

            user.Perfil = vendedor;

            context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;

            context.SaveChanges();
        }
    }
}
