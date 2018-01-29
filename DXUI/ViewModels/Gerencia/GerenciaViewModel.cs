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
    /// Represents the single Gerencia object view model.
    /// </summary>
    public partial class GerenciaViewModel : SingleObjectViewModel<Gerencia, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of GerenciaViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static GerenciaViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new GerenciaViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the GerenciaViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the GerenciaViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected GerenciaViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.Gerencia, x => x.ImagenUrl) {
                }



    }
}
