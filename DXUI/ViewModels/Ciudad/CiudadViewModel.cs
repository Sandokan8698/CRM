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
    /// Represents the single Ciudad object view model.
    /// </summary>
    public partial class CiudadViewModel : SingleObjectViewModel<Ciudad, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of CiudadViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static CiudadViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new CiudadViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the CiudadViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the CiudadViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected CiudadViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.CiudadDbSet, x => x.Nombre) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of ProviciaDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Provincia> LookUpProviciaDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (CiudadViewModel x) => x.LookUpProviciaDbSet,
                    getRepositoryFunc: x => x.ProviciaDbSet);
            }
        }

    }
}
