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
    /// Represents the single Tarea object view model.
    /// </summary>
    public partial class TareaViewModel : SingleObjectViewModel<Tarea, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of TareaViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TareaViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new TareaViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the TareaViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the TareaViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TareaViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.TareaDbSet, x => x.Descripcion) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of UserDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<User> LookUpUserDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (TareaViewModel x) => x.LookUpUserDbSet,
                    getRepositoryFunc: x => x.UserDbSet);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of TareaHistorials for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<TareaHistorial> LookUpTareaHistorials {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (TareaViewModel x) => x.LookUpTareaHistorials,
                    getRepositoryFunc: x => x.TareaHistorials);
            }
        }


        /// <summary>
        /// The view model for the TareaHistorial detail collection.
        /// </summary>
        public CollectionViewModelBase<TareaHistorial, TareaHistorial, int, ICRMContexUnitOfWork> TareaHistorialDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (TareaViewModel x) => x.TareaHistorialDetails,
                    getRepositoryFunc: x => x.TareaHistorials,
                    foreignKeyExpression: x => x.TareaId,
                    navigationExpression: x => x.Tarea);
            }
        }
    }
}
