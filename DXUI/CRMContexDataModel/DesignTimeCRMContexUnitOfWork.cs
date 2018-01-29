using Data;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.DataModel.DesignTime;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DXUI.CRMContexDataModel {

    /// <summary>
    /// A CRMContexDesignTimeUnitOfWork instance that represents the design-time implementation of the ICRMContexUnitOfWork interface.
    /// </summary>
    public class CRMContexDesignTimeUnitOfWork : DesignTimeUnitOfWork, ICRMContexUnitOfWork {

        /// <summary>
        /// Initializes a new instance of the CRMContexDesignTimeUnitOfWork class.
        /// </summary>
        public CRMContexDesignTimeUnitOfWork() {
        }

        IRepository<Ciudad, int> ICRMContexUnitOfWork.CiudadDbSet {
            get { return GetRepository((Ciudad x) => x.CiudadId); }
        }

        IRepository<Provincia, int> ICRMContexUnitOfWork.ProviciaDbSet {
            get { return GetRepository((Provincia x) => x.ProvinciaId); }
        }

        IRepository<Claim, int> ICRMContexUnitOfWork.ClaimDbSet {
            get { return GetRepository((Claim x) => x.ClaimId); }
        }

        IRepository<User, int> ICRMContexUnitOfWork.UserDbSet {
            get { return GetRepository((User x) => x.UserId); }
        }

        IRepository<ExternalLogin, int> ICRMContexUnitOfWork.ExternalLoginDbSet {
            get { return GetRepository((ExternalLogin x) => x.ExternalLoginId); }
        }

        IRepository<Perfil, int> ICRMContexUnitOfWork.PefilDbset {
            get { return GetRepository((Perfil x) => x.PerfilId); }
        }

        IRepository<Gerencia, int> ICRMContexUnitOfWork.Gerencia {
            get { return GetRepository((Gerencia x) => x.PerfilId); }
        }

        IRepository<Vendedor, int> ICRMContexUnitOfWork.Vendedor {
            get { return GetRepository((Vendedor x) => x.PerfilId); }
        }

        IRepository<Cliente, int> ICRMContexUnitOfWork.Clientes {
            get { return GetRepository((Cliente x) => x.ClienteId); }
        }

        IRepository<Contacto, int> ICRMContexUnitOfWork.ContactoDbSet {
            get { return GetRepository((Contacto x) => x.ContactoId); }
        }

        IRepository<Oportunidad, int> ICRMContexUnitOfWork.OportunidadDsDbSet {
            get { return GetRepository((Oportunidad x) => x.OportunidadId); }
        }

        IRepository<Etapa, int> ICRMContexUnitOfWork.Etapas {
            get { return GetRepository((Etapa x) => x.EtapaId); }
        }

        IRepository<LineaNegocio, int> ICRMContexUnitOfWork.LineaNegocios {
            get { return GetRepository((LineaNegocio x) => x.LineaNegocioId); }
        }

        IRepository<Producto, int> ICRMContexUnitOfWork.Productoes {
            get { return GetRepository((Producto x) => x.ProductoId); }
        }

        IRepository<TipoGestion, int> ICRMContexUnitOfWork.TipoGestions {
            get { return GetRepository((TipoGestion x) => x.TipoGestionId); }
        }

        IRepository<Role, int> ICRMContexUnitOfWork.RoleDbSet {
            get { return GetRepository((Role x) => x.RoleId); }
        }

        IRepository<Tarea, int> ICRMContexUnitOfWork.TareaDbSet {
            get { return GetRepository((Tarea x) => x.TareaId); }
        }

        IRepository<TareaHistorial, int> ICRMContexUnitOfWork.TareaHistorials {
            get { return GetRepository((TareaHistorial x) => x.TareaHistorialId); }
        }
    }
}
