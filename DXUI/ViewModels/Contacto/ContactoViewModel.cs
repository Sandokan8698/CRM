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
    /// Represents the single Contacto object view model.
    /// </summary>
    public partial class ContactoViewModel : SingleObjectViewModel<Contacto, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ContactoViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ContactoViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ContactoViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ContactoViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ContactoViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ContactoViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.ContactoDbSet, x => x.Nombre) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Clientes for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Cliente> LookUpClientes {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ContactoViewModel x) => x.LookUpClientes,
                    getRepositoryFunc: x => x.Clientes);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of OportunidadDsDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Oportunidad> LookUpOportunidadDsDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ContactoViewModel x) => x.LookUpOportunidadDsDbSet,
                    getRepositoryFunc: x => x.OportunidadDsDbSet);
            }
        }


        /// <summary>
        /// The view model for the ContactoOportunidadesContactoVenta detail collection.
        /// </summary>
        public CollectionViewModelBase<Oportunidad, Oportunidad, int, ICRMContexUnitOfWork> ContactoOportunidadesContactoVentaDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (ContactoViewModel x) => x.ContactoOportunidadesContactoVentaDetails,
                    getRepositoryFunc: x => x.OportunidadDsDbSet,
                    foreignKeyExpression: x => x.ContactoVentaId,
                    navigationExpression: x => x.ContactoVenta);
            }
        }

        /// <summary>
        /// The view model for the ContactoOportunidadesTomadorDesicion detail collection.
        /// </summary>
        public CollectionViewModelBase<Oportunidad, Oportunidad, int, ICRMContexUnitOfWork> ContactoOportunidadesTomadorDesicionDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (ContactoViewModel x) => x.ContactoOportunidadesTomadorDesicionDetails,
                    getRepositoryFunc: x => x.OportunidadDsDbSet,
                    foreignKeyExpression: x => x.TomadorDescicionId,
                    navigationExpression: x => x.TomadorDesicion);
            }
        }
    }
}
