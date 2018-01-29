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
    /// Represents the single ExternalLogin object view model.
    /// </summary>
    public partial class ExternalLoginViewModel : SingleObjectViewModel<ExternalLogin, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of ExternalLoginViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static ExternalLoginViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new ExternalLoginViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the ExternalLoginViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the ExternalLoginViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected ExternalLoginViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.ExternalLoginDbSet, x => x.LoginProvider) {
                }


        /// <summary>
        /// The view model that contains a look-up collection of UserDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<User> LookUpUserDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (ExternalLoginViewModel x) => x.LookUpUserDbSet,
                    getRepositoryFunc: x => x.UserDbSet);
            }
        }

    }
}
