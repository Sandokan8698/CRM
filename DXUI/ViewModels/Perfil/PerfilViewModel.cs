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
    /// Represents the single Perfil object view model.
    /// </summary>
    public partial class PerfilViewModel : SingleObjectViewModel<Perfil, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of PerfilViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static PerfilViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new PerfilViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the PerfilViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the PerfilViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected PerfilViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.PefilDbset, x => x.ImagenUrl) {
                }



    }
}
