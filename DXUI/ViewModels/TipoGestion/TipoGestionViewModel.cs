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
    /// Represents the single TipoGestion object view model.
    /// </summary>
    public partial class TipoGestionViewModel : SingleObjectViewModel<TipoGestion, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of TipoGestionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static TipoGestionViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new TipoGestionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the TipoGestionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the TipoGestionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected TipoGestionViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.TipoGestions, x => x.Descripcion) {
                }



    }
}
