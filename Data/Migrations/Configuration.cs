using System.Collections.Generic;
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

            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 1, Nombre = "Carchi" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 2, Nombre = "Imbabura" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 3, Nombre = "Pichincha" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 4, Nombre = "Cotopaxi" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 5, Nombre = "Tungurahua" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 6, Nombre = "Bolívar" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 7, Nombre = "Chimborazo" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 8, Nombre = "Cañar" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 9, Nombre = "Azuay" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 10, Nombre = "Loja" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 11, Nombre = "Sto. Domingo de los Tsachilas" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 12, Nombre = "Sucumbíos" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 13, Nombre = "Napo" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 14, Nombre = "Pastaza" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 15, Nombre = "Orellana" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 16, Nombre = "Morona Santiago" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 17, Nombre = "Zamora Chinchipe" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 18, Nombre = "Guayas" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 19, Nombre = "Los Ríos" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 20, Nombre = "El Oro" });
            context.ProviciaDbSet.AddOrUpdate(new Provincia { ProvinciaId = 21, Nombre = "Santa Elena" });




            context.CiudadDbSet.AddOrUpdate(new Ciudad {CiudadId = 1, ProvinciaId = 1, Nombre = "Tulcán" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad {CiudadId = 2, ProvinciaId = 1, Nombre = "Montufar" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad {CiudadId = 3, ProvinciaId = 1, Nombre = "Espejo" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad {CiudadId = 4, ProvinciaId = 1, Nombre = "Mira" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad {CiudadId = 6, ProvinciaId = 1, Nombre = "Bolívar" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad {CiudadId = 7, ProvinciaId = 1, Nombre = "Huaca" });


            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 8, ProvinciaId = 2, Nombre = "Ibarra" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 9, ProvinciaId = 2, Nombre = "Otavalo" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 10, ProvinciaId = 2, Nombre = "Cotacachi" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 11, ProvinciaId = 2, Nombre = "Antonio Ante" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 12, ProvinciaId = 2, Nombre = "Pimampiro" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 13, ProvinciaId = 2, Nombre = "Urcuqui" });

            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 14, ProvinciaId = 3, Nombre = "Puerto Quito" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 15, ProvinciaId = 3, Nombre = "Pedro Vicente Maldonado" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 16, ProvinciaId = 3, Nombre = "Rumiñahui" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 17, ProvinciaId = 3, Nombre = "Mejía" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 18, ProvinciaId = 3, Nombre = "Pedro Moncayo" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 19, ProvinciaId = 3, Nombre = "Bancos" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 20, ProvinciaId = 3, Nombre = "Cayambe" });

            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 21, ProvinciaId = 4, Nombre = "Latacunga" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 22, ProvinciaId = 4, Nombre = "La Maná" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 23, ProvinciaId = 4, Nombre = "Pangua" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 24, ProvinciaId = 4, Nombre = "Pujilí" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 25, ProvinciaId = 4, Nombre = "Salcedo" });
            context.CiudadDbSet.AddOrUpdate(new Ciudad { CiudadId = 26, ProvinciaId = 4, Nombre = "Sigchos" });
            

        }

    }
}
