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
    /// Represents the single User object view model.
    /// </summary>
    public partial class UserViewModel : SingleObjectViewModel<User, int, ICRMContexUnitOfWork> {

        /// <summary>
        /// Creates a new instance of UserViewModel as a POCO view model.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        public static UserViewModel Create(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null) {
            return ViewModelSource.Create(() => new UserViewModel(unitOfWorkFactory));
        }

        /// <summary>
        /// Initializes a new instance of the UserViewModel class.
        /// This constructor is declared protected to avoid undesired instantiation of the UserViewModel type without the POCO proxy factory.
        /// </summary>
        /// <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        protected UserViewModel(IUnitOfWorkFactory<ICRMContexUnitOfWork> unitOfWorkFactory = null)
            : base(unitOfWorkFactory ?? UnitOfWorkSource.GetUnitOfWorkFactory(), x => x.UserDbSet, x => x.UserName) {
                }


        protected override void RefreshLookUpCollections(bool raisePropertyChanged) {
            base.RefreshLookUpCollections(raisePropertyChanged);
                RolesDetailEntities = CreateAddRemoveDetailEntitiesViewModel(x => x.RoleDbSet, x => x.Roles);
        }
        /// <summary>
        /// The view model that contains a look-up collection of ClaimDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Claim> LookUpClaimDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (UserViewModel x) => x.LookUpClaimDbSet,
                    getRepositoryFunc: x => x.ClaimDbSet);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of PefilDbset for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Perfil> LookUpPefilDbset {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (UserViewModel x) => x.LookUpPefilDbset,
                    getRepositoryFunc: x => x.PefilDbset);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of ExternalLoginDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<ExternalLogin> LookUpExternalLoginDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (UserViewModel x) => x.LookUpExternalLoginDbSet,
                    getRepositoryFunc: x => x.ExternalLoginDbSet);
            }
        }
        /// <summary>
        /// The view model that contains a look-up collection of TareaDbSet for the corresponding navigation property in the view.
        /// </summary>
        public IEntitiesViewModel<Tarea> LookUpTareaDbSet {
            get {
                return GetLookUpEntitiesViewModel(
                    propertyExpression: (UserViewModel x) => x.LookUpTareaDbSet,
                    getRepositoryFunc: x => x.TareaDbSet);
            }
        }

    public virtual AddRemoveDetailEntitiesViewModel<User, Int32, Role, Int32, ICRMContexUnitOfWork> RolesDetailEntities { get; protected set; }

        /// <summary>
        /// The view model for the UserClaims detail collection.
        /// </summary>
        public CollectionViewModelBase<Claim, Claim, int, ICRMContexUnitOfWork> UserClaimsDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (UserViewModel x) => x.UserClaimsDetails,
                    getRepositoryFunc: x => x.ClaimDbSet,
                    foreignKeyExpression: x => x.UserId,
                    navigationExpression: x => x.User);
            }
        }

        /// <summary>
        /// The view model for the UserLogins detail collection.
        /// </summary>
        public CollectionViewModelBase<ExternalLogin, ExternalLogin, int, ICRMContexUnitOfWork> UserLoginsDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (UserViewModel x) => x.UserLoginsDetails,
                    getRepositoryFunc: x => x.ExternalLoginDbSet,
                    foreignKeyExpression: x => x.UserId,
                    navigationExpression: x => x.User);
            }
        }

        /// <summary>
        /// The view model for the UserTareasAsignadas detail collection.
        /// </summary>
        public CollectionViewModelBase<Tarea, Tarea, int, ICRMContexUnitOfWork> UserTareasAsignadasDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (UserViewModel x) => x.UserTareasAsignadasDetails,
                    getRepositoryFunc: x => x.TareaDbSet,
                    foreignKeyExpression: x => x.AsignadoAId,
                    navigationExpression: x => x.AsignadoA);
            }
        }

        /// <summary>
        /// The view model for the UserTareasCreadas detail collection.
        /// </summary>
        public CollectionViewModelBase<Tarea, Tarea, int, ICRMContexUnitOfWork> UserTareasCreadasDetails {
            get {
                return GetDetailsCollectionViewModel(
                    propertyExpression: (UserViewModel x) => x.UserTareasCreadasDetails,
                    getRepositoryFunc: x => x.TareaDbSet,
                    foreignKeyExpression: x => x.CreadoPorId,
                    navigationExpression: x => x.CreadoPor);
            }
        }
    }
}
