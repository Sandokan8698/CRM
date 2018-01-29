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
    /// Represents the single Role object view model.
    /// </summary>
    public partial class RoleViewModel : SingleObjectViewModel<Role, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of RoleViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static RoleViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new RoleViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the RoleViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the RoleViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected RoleViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.RoleDbSet, x => x.Name) {
                }


        protected override void RefreshLookUpCollections(bool raisePropertyChanged) {
            base.RefreshLookUpCollections(raisePropertyChanged);
                UsersDetailEntities = CreateAddRemoveDetailEntitiesViewModel(x => x.UserDbSet, x => x.Users);
        }

    public virtual AddRemoveDetailEntitiesViewModel<Role, Int32, User, Int32, ICRMContexUnitOfWork> UsersDetailEntities { get; protected set; }
    }
}
