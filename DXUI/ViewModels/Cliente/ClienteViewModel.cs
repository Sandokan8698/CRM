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
    /// Represents the single Cliente object view model.
    /// </summary>
    public partial class ClienteViewModel : SingleObjectViewModel<Cliente, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ClienteViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ClienteViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ClienteViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ClienteViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ClienteViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ClienteViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Clientes, x => x.DescripcionSector) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of CiudadDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Ciudad> LookUpCiudadDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ClienteViewModel x) => x.LookUpCiudadDbSet,
                    getRepositoryFunc: x => x.CiudadDbSet);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of ProviciaDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Provincia> LookUpProviciaDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ClienteViewModel x) => x.LookUpProviciaDbSet,
                    getRepositoryFunc: x => x.ProviciaDbSet);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of Vendedor for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Vendedor> LookUpVendedor {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ClienteViewModel x) => x.LookUpVendedor,
                    getRepositoryFunc: x => x.Vendedor);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of ContactoDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Contacto> LookUpContactoDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ClienteViewModel x) => x.LookUpContactoDbSet,
                    getRepositoryFunc: x => x.ContactoDbSet);
            }
        }


        /// <summary>
        /// The view model for the ClienteContactos detail collection.
        /// </summary>
        public CollectionViewModelBase<Contacto, Contacto, int, ICRMContexUnitOfWork> ClienteContactosDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (ClienteViewModel x) => x.ClienteContactosDetails,
                    getRepositoryFunc: x => x.ContactoDbSet,
                    foreignKeyExpression: x => x.ClienteId,
                    navigationExpression: x => x.Cliente);
            }
        }
    }
}
