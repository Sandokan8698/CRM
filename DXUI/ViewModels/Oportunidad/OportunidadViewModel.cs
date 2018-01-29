using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using DXUI.CRMContexDataModel;
using DXUI.Common;
using Domain.Entities;

namespace DXUI.ViewModels {

    /// <summary>
    /// Represents the single Oportunidad object view model.
    /// </summary>
    public partial class OportunidadViewModel : SingleObjectViewModel<Oportunidad, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of OportunidadViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static OportunidadViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new OportunidadViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the OportunidadViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the OportunidadViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected OportunidadViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.OportunidadDsDbSet, x => x.Nombre) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Vendedor for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Vendedor> LookUpVendedor {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (OportunidadViewModel x) => x.LookUpVendedor,
                    getRepositoryFunc: x => x.Vendedor);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Clientes for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Cliente> LookUpClientes {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (OportunidadViewModel x) => x.LookUpClientes,
                    getRepositoryFunc: x => x.Clientes);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of ContactoDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Contacto> LookUpContactoDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (OportunidadViewModel x) => x.LookUpContactoDbSet,
                    getRepositoryFunc: x => x.ContactoDbSet);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Etapas for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Etapa> LookUpEtapas {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (OportunidadViewModel x) => x.LookUpEtapas,
                    getRepositoryFunc: x => x.Etapas);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of LineaNegocios for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<LineaNegocio> LookUpLineaNegocios {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (OportunidadViewModel x) => x.LookUpLineaNegocios,
                    getRepositoryFunc: x => x.LineaNegocios);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Productoes for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Producto> LookUpProductoes {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (OportunidadViewModel x) => x.LookUpProductoes,
                    getRepositoryFunc: x => x.Productoes);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of TipoGestions for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<TipoGestion> LookUpTipoGestions {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (OportunidadViewModel x) => x.LookUpTipoGestions,
                    getRepositoryFunc: x => x.TipoGestions);
            }
        }

    }
}
