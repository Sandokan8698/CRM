using Data;
using DevExpress.Mvvm.DataModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DXUI.CRMContexDataModel {

    /// <summary>
    /// ICRMContexUnitOfWork extends the IUnitOfWork interface with repositories representing specific entities.
    /// </summary>
    public interface ICRMContexUnitOfWork : IUnitOfWork {
        
        /// <summary>
        /// The Ciudad entities repository.
        /// </summary>
		IRepository<Ciudad, int> CiudadDbSet { get; }
        
        /// <summary>
        /// The Provincia entities repository.
        /// </summary>
		IRepository<Provincia, int> ProviciaDbSet { get; }
        
        /// <summary>
        /// The Claim entities repository.
        /// </summary>
		IRepository<Claim, int> ClaimDbSet { get; }
        
        /// <summary>
        /// The User entities repository.
        /// </summary>
		IRepository<User, int> UserDbSet { get; }
        
        /// <summary>
        /// The ExternalLogin entities repository.
        /// </summary>
		IRepository<ExternalLogin, int> ExternalLoginDbSet { get; }
        
        /// <summary>
        /// The Perfil entities repository.
        /// </summary>
		IRepository<Perfil, int> PefilDbset { get; }
        
        /// <summary>
        /// The Gerencia entities repository.
        /// </summary>
		IRepository<Gerencia, int> Gerencia { get; }
        
        /// <summary>
        /// The Vendedor entities repository.
        /// </summary>
		IRepository<Vendedor, int> Vendedor { get; }
        
        /// <summary>
        /// The Cliente entities repository.
        /// </summary>
		IRepository<Cliente, int> Clientes { get; }
        
        /// <summary>
        /// The Contacto entities repository.
        /// </summary>
		IRepository<Contacto, int> ContactoDbSet { get; }
        
        /// <summary>
        /// The Oportunidad entities repository.
        /// </summary>
		IRepository<Oportunidad, int> OportunidadDsDbSet { get; }
        
        /// <summary>
        /// The Etapa entities repository.
        /// </summary>
		IRepository<Etapa, int> Etapas { get; }
        
        /// <summary>
        /// The LineaNegocio entities repository.
        /// </summary>
		IRepository<LineaNegocio, int> LineaNegocios { get; }
        
        /// <summary>
        /// The Producto entities repository.
        /// </summary>
		IRepository<Producto, int> Productoes { get; }
        
        /// <summary>
        /// The TipoGestion entities repository.
        /// </summary>
		IRepository<TipoGestion, int> TipoGestions { get; }
        
        /// <summary>
        /// The Role entities repository.
        /// </summary>
		IRepository<Role, int> RoleDbSet { get; }
        
        /// <summary>
        /// The Tarea entities repository.
        /// </summary>
		IRepository<Tarea, int> TareaDbSet { get; }
        
        /// <summary>
        /// The TareaHistorial entities repository.
        /// </summary>
		IRepository<TareaHistorial, int> TareaHistorials { get; }
    }
}
