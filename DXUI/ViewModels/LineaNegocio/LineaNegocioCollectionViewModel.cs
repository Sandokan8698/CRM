using System;
using System.Linq;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataModel;
using DevExpress.Mvvm.ViewModel;
using DXUI.CRMContexDataModel;
using DXUI.Common;
using Domain.Entities;

namespace DXUI.ViewModels {

    /// <summary>
    /// Represents the LineaNegocios collection view model.
    /// </summary>
    public partial class LineaNegocioCollectionViewModel : CollectionViewModel<LineaNegocio, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of LineaNegocioCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static LineaNegocioCollectionViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new LineaNegocioCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the LineaNegocioCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the LineaNegocioCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected LineaNegocioCollectionViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.LineaNegocios) {
        }
    }
}