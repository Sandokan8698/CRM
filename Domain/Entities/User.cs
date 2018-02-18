using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User: BaseEntity<User>
    {
      #region Scalar Properties

        public int UserId { get; set; }

        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        public virtual string PasswordHash { get; set; }

        [NotMapped]
       
        [Compare("PasswordHash", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [MaxLength(15)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(15)]
        [Required]
        public string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        public virtual string SecurityStamp { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Claim> Claims { get; set; }
        

        public virtual ICollection<ExternalLogin> Logins { get; set; } 

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Tarea> TareasCreadas { get; set; }
        public virtual ICollection<Tarea> TareasAsignadas { get; set; }

        public virtual ICollection<ReasignacionHistorial> Reasignaciones { get; set; }
        public virtual ICollection<ReasignacionHistorial> ResasignacionesFrom { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

        [MaxLength(15)]
        public string Celular { get; set; }

        public virtual Perfil Perfil { get; set; }

        public User()
        {
            Roles = new HashSet<Role>();
            TareasCreadas = new HashSet<Tarea>();
            TareasAsignadas = new HashSet<Tarea>();
            Reasignaciones = new HashSet<ReasignacionHistorial>();
            ResasignacionesFrom = new HashSet<ReasignacionHistorial>();
            Clientes = new HashSet<Cliente>();
        }

        #endregion
    }
}
