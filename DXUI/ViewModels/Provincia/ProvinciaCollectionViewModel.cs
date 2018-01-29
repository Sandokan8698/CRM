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
    /// Represents the ProviciaDbSet collection view model.
    /// </summary>
    public partial class ProvinciaCollectionViewModel : CollectionViewModel<Provincia, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ProvinciaCollectionViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ProvinciaCollectionViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ProvinciaCollectionViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ProvinciaCollectionViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ProvinciaCollectionViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ProvinciaCollectionViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.ProviciaDbSet) {
        }
    }
}