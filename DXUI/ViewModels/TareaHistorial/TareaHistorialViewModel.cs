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
    /// Represents the single TareaHistorial object view model.
    /// </summary>
    public partial class TareaHistorialViewModel : SingleObjectViewModel<TareaHistorial, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of TareaHistorialViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TareaHistorialViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new TareaHistorialViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the TareaHistorialViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the TareaHistorialViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TareaHistorialViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.TareaHistorials, x => x.Descripcion) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of TareaDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Tarea> LookUpTareaDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (TareaHistorialViewModel x) => x.LookUpTareaDbSet,
                    getRepositoryFunc: x => x.TareaDbSet);
            }
        }

    }
}
