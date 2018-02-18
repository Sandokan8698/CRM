using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<Oportunidad> OportunidadDsDbSet { get; set; }
        public DbSet<Contacto> ContactoDbSet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Ruc)
                .IsUnique(true);

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

            modelBuilder.Entity<ReasignacionHistorial>()
                .HasRequired(r => r.ReasignadoPor)
                .WithMany(u => u.Reasignaciones)
                .HasForeignKey(r => r.ReasignadoPorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReasignacionHistorial>()
                .HasRequired(r => r.ReasignadoA)
                .WithMany(u => u.ResasignacionesFrom)
                .HasForeignKey(r => r.ReasignadoAId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oportunidad>()
                .HasRequired(m => m.Asesor)
                .WithMany(v => v.Oportunidades)
                .HasForeignKey(m => m.AsesorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Oportunidad>()
                .HasRequired(m => m.ContactoVenta)
                .WithMany(c => c.OportunidadesContactoVenta)
                .HasForeignKey(m => m.ContactoVentaId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .HasOptional(c => c.TomaDescicion)
                .WithRequired(t => t.Cliente);

            modelBuilder.Entity<Cliente>()
                .HasOptional(c => c.Sendero)
                .WithRequired(s => s.Cliente);

            modelBuilder.Entity<SenderoProducto>()
                .HasKey(s => new {s.SenderoId, s.ProductoId});

            modelBuilder.Entity<SenderoProducto>()
                .HasRequired(sp => sp.Producto)
                .WithMany(s => s.SenderoProducto)
                .HasForeignKey(sp => sp.ProductoId);

            modelBuilder.Entity<SenderoProducto>()
                .HasRequired(sp => sp.Sendero)
                .WithMany(s => s.SenderoProducto)
                .HasForeignKey(sp => sp.ProductoId);

        }
    }
}
