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
    /// Represents the single Vendedor object view model.
    /// </summary>
    public partial class VendedorViewModel : SingleObjectViewModel<Vendedor, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of VendedorViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static VendedorViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new VendedorViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the VendedorViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the VendedorViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected VendedorViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Vendedor, x => x.ImagenUrl) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of Clientes for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Cliente> LookUpClientes {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (VendedorViewModel x) => x.LookUpClientes,
                    getRepositoryFunc: x => x.Clientes);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of OportunidadDsDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Oportunidad> LookUpOportunidadDsDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (VendedorViewModel x) => x.LookUpOportunidadDsDbSet,
                    getRepositoryFunc: x => x.OportunidadDsDbSet);
            }
        }


        /// <summary>
        /// The view model for the VendedorOportunidades detail collection.
        /// </summary>
        public CollectionViewModelBase<Oportunidad, Oportunidad, int, ICRMContexUnitOfWork> VendedorOportunidadesDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (VendedorViewModel x) => x.VendedorOportunidadesDetails,
                    getRepositoryFunc: x => x.OportunidadDsDbSet,
                    foreignKeyExpression: x => x.AsesorId,
                    navigationExpression: x => x.Asesor);
            }
        }
    }
}
