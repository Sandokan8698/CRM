﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class User
    {
        #region Fields
        private ICollection<Claim> _claims;
        private ICollection<ExternalLogin> _externalLogins;
        private ICollection<Role> _roles;
        private ICollection<Tarea> _tareasCreadas;
        private ICollection<Tarea> _tareasAsignadas;
        #endregion

        #region Scalar Properties

        public int UserId { get; set; }

        [Required]
        [MaxLength(15)]
        public string UserName { get; set; }

        [Required]
        public virtual string PasswordHash { get; set; }

        [Required]
        public virtual string SecurityStamp { get; set; }
        #endregion

        #region Navigation Properties
        public virtual ICollection<Claim> Claims
        {
            get { return _claims ?? (_claims = new List<Claim>()); }
            set { _claims = value; }
        }

        public virtual ICollection<ExternalLogin> Logins
        {
            get
            {
                return _externalLogins ??
                    (_externalLogins = new List<ExternalLogin>());
            }
            set { _externalLogins = value; }
        }

        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            set { _roles = value; }
        }

        public ICollection<Tarea> TareasCreadas { get; set; }
        public ICollection<Tarea> TareasAsignadas { get; set; }

        public virtual Perfil Perfil { get; set; }

        #endregion
    }
}
