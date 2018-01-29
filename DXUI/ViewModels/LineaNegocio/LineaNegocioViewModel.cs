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
    /// Represents the single LineaNegocio object view model.
    /// </summary>
    public partial class LineaNegocioViewModel : SingleObjectViewModel<LineaNegocio, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of LineaNegocioViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static LineaNegocioViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new LineaNegocioViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the LineaNegocioViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the LineaNegocioViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected LineaNegocioViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.LineaNegocios, x => x.Descripcion) {
                }



    }
}
