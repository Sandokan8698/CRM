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
    /// Represents the single Provincia object view model.
    /// </summary>
    public partial class ProvinciaViewModel : SingleObjectViewModel<Provincia, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ProvinciaViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ProvinciaViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ProvinciaViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ProvinciaViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ProvinciaViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ProvinciaViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.ProviciaDbSet, x => x.Nombre) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of CiudadDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Ciudad> LookUpCiudadDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ProvinciaViewModel x) => x.LookUpCiudadDbSet,
                    getRepositoryFunc: x => x.CiudadDbSet);
            }
        }


        /// <summary>
        /// The view model for the ProvinciaCantones detail collection.
        /// </summary>
        public CollectionViewModelBase<Ciudad, Ciudad, int, ICRMContexUnitOfWork> ProvinciaCantonesDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (ProvinciaViewModel x) => x.ProvinciaCantonesDetails,
                    getRepositoryFunc: x => x.CiudadDbSet,
                    foreignKeyExpression: x => x.ProvinciaId,
                    navigationExpression: x => x.Provincia);
            }
        }
    }
}
