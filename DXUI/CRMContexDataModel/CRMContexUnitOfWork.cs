using Data;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.EF6;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DXUI.CRMContexDataModel {

    /// <summary>
    /// A CRMContexUnitOfWork instance that represents the run-time implementation of the ICRMContexUnitOfWork interface.
    /// </summary>
    public class CRMContexUnitOfWork : DbUnitOfWork<CRMContex>, ICRMContexUnitOfWork {

        public CRMContexUnitOfWork(Func<CRMContex> contextFactory)
            : base(contextFactory) {
        }

        IRepository<Ciudad, int> ICRMContexUnitOfWork.CiudadDbSet {
            get { return GetRepository(x => x.Set<Ciudad>(), (Ciudad x) => x.CiudadId); }
        }

        IRepository<Provincia, int> ICRMContexUnitOfWork.ProviciaDbSet {
            get { return GetRepository(x => x.Set<Provincia>(), (Provincia x) => x.ProvinciaId); }
        }

        IRepository<Claim, int> ICRMContexUnitOfWork.ClaimDbSet {
            get { return GetRepository(x => x.Set<Claim>(), (Claim x) => x.ClaimId); }
        }

        IRepository<User, int> ICRMContexUnitOfWork.UserDbSet {
            get { return GetRepository(x => x.Set<User>(), (User x) => x.UserId); }
        }

        IRepository<ExternalLogin, int> ICRMContexUnitOfWork.ExternalLoginDbSet {
            get { return GetRepository(x => x.Set<ExternalLogin>(), (ExternalLogin x) => x.ExternalLoginId); }
        }

        IRepository<Perfil, int> ICRMContexUnitOfWork.PefilDbset {
            get { return GetRepository(x => x.Set<Perfil>(), (Perfil x) => x.PerfilId); }
        }

        IRepository<Gerencia, int> ICRMContexUnitOfWork.Gerencia {
            get { return GetRepository(x => x.Set<Gerencia>(), (Gerencia x) => x.PerfilId); }
        }

        IRepository<Vendedor, int> ICRMContexUnitOfWork.Vendedor {
            get { return GetRepository(x => x.Set<Vendedor>(), (Vendedor x) => x.PerfilId); }
        }

        IRepository<Cliente, int> ICRMContexUnitOfWork.Clientes {
            get { return GetRepository(x => x.Set<Cliente>(), (Cliente x) => x.ClienteId); }
        }

        IRepository<Contacto, int> ICRMContexUnitOfWork.ContactoDbSet {
            get { return GetRepository(x => x.Set<Contacto>(), (Contacto x) => x.ContactoId); }
        }

        IRepository<Oportunidad, int> ICRMContexUnitOfWork.OportunidadDsDbSet {
            get { return GetRepository(x => x.Set<Oportunidad>(), (Oportunidad x) => x.OportunidadId); }
        }

        IRepository<Etapa, int> ICRMContexUnitOfWork.Etapas {
            get { return GetRepository(x => x.Set<Etapa>(), (Etapa x) => x.EtapaId); }
        }

        IRepository<LineaNegocio, int> ICRMContexUnitOfWork.LineaNegocios {
            get { return GetRepository(x => x.Set<LineaNegocio>(), (LineaNegocio x) => x.LineaNegocioId); }
        }

        IRepository<Producto, int> ICRMContexUnitOfWork.Productoes {
            get { return GetRepository(x => x.Set<Producto>(), (Producto x) => x.ProductoId); }
        }

        IRepository<TipoGestion, int> ICRMContexUnitOfWork.TipoGestions {
            get { return GetRepository(x => x.Set<TipoGestion>(), (TipoGestion x) => x.TipoGestionId); }
        }

        IRepository<Role, int> ICRMContexUnitOfWork.RoleDbSet {
            get { return GetRepository(x => x.Set<Role>(), (Role x) => x.RoleId); }
        }

        IRepository<Tarea, int> ICRMContexUnitOfWork.TareaDbSet {
            get { return GetRepository(x => x.Set<Tarea>(), (Tarea x) => x.TareaId); }
        }

        IRepository<TareaHistorial, int> ICRMContexUnitOfWork.TareaHistorials {
            get { return GetRepository(x => x.Set<TareaHistorial>(), (TareaHistorial x) => x.TareaHistorialId); }
        }
    }
}
