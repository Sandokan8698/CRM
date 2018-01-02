using Domain.Entities;

namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRMContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRMContex context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var usuario = context.UserDbSet.FirstOrDefault();
            //var vendedor = new Vendedor {UserName = usuario.UserName, PasswordHash = usuario.PasswordHash, SecurityStamp =  usuario.SecurityStamp, UserId = 1};
            //var gerente = new Gerente{UserName = usuario.UserName, PasswordHash = usuario.PasswordHash, SecurityStamp =  usuario.SecurityStamp, UserId =2};
            
            

            //context.VendedorDbSet.AddOrUpdate(vendedor);
            //context.GerenteDbSet.AddOrUpdate(gerente);

            //context.GroupDbSet.AddOrUpdate(new Group {GroupId = 1, UserId =  vendedor.UserId});
        }
    }
}
