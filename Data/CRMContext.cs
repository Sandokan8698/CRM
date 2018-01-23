using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;


namespace Data
{
    
    public class CRMContex: DbContext
    {
        public CRMContex():base("name=CRM")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }
        

        public DbSet<User> UserDbSet { get; set; }
        public DbSet<Claim> ClaimDbSet { get; set; }
        public DbSet<ExternalLogin> ExternalLoginDbSet { get; set; }
        public DbSet<Role> RoleDbSet { get; set; }
        public DbSet<Tarea> TareaDbSet { get; set; }
        public DbSet<Perfil> PefilDbset { get; set; }
        public DbSet<Provincia> ProviciaDbSet  { get; set; }
        public DbSet<Ciudad> CiudadDbSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Tarea>()
                    .HasRequired(m => m.AsignadoA)
                    .WithMany(t => t.TareasAsignadas)
                    .HasForeignKey(m => m.AsignadoAId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tarea>()
                  .HasRequired(m => m.CreadoPor)
                  .WithMany(t => t.TareasCreadas)
                  .HasForeignKey(m => m.CreadoPorId)
                  .WillCascadeOnDelete(false);

        }
    }
}
