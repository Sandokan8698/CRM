using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Domain.Entities;



namespace UI.ViewModel.User
{
    public class UserViewModel: SingleObjectViewModel<Domain.Entities.User>
    {
        public Domain.Entities.User User
        {
            get { return GetProperty(() => User); }
            set { SetProperty(() => User, value); }
        }
        
        public List<Role> Roles
        {
            get { return GetProperty(() => Roles); }
            set { SetProperty(() => Roles, value); }
        }

        public Role SelectedRole
        {
            get { return GetProperty(() => SelectedRole); }
            set { SetProperty(() => SelectedRole, value); }
        }

        #region Commands

        public DelegateCommand SaveUserCommand { get; private set; }
        public DelegateCommand FindUserCommand { get; private set; }
        public DelegateCommand DeleteUserCommand { get; private set; }
        public DelegateCommand NewUserCommand { get; private set; }
        public DelegateCommand<string> OucaptionChangeCommand { get; set; }
       
        #endregion


        #region  Ctor

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            SaveUserCommand = new DelegateCommand(SaveUser);
            FindUserCommand = new DelegateCommand(FindUser);
            DeleteUserCommand = new DelegateCommand(DeleteUser, CanDeleteUser);
            NewUserCommand = new DelegateCommand(NewUser);
          
            Roles = UnitOfWork.RoleRepository.GetAll();

            User = new Domain.Entities.User();
        }

        #endregion

        #region Methods

        private void NewUser()
        {
           User = new Domain.Entities.User();
          
        }

        private void DeleteUser()
        {
            if (ShowWarningWithResultMesage("El Usuario sera eliminado permanentemente, desea continuar") ==
                MessageBoxResult.OK)
            {
                try
                {
                    UnitOfWork.UserRepository.Remove(User);
                    UnitOfWork.SaveChanges();

                    ShowSuccesMensage("El usuario se elimino con éxito");

                    User = new Domain.Entities.User();
                  
                }
                catch (Exception e)
                {
                    ShowErrorMensage(e.Message);
                }
            }
        }

        private bool CanDeleteUser()
        {
            return User.UserId > 0;
        }

        void AddUser()
        {
            if (!Service.UserHasRole(User, SelectedRole))
            {
                UnitOfWork.RoleRepository.RemoveAll(User.Roles);
                User.Roles.Add(SelectedRole);
            }
            
            UnitOfWork.UserRepository.Add(User);
            UnitOfWork.SaveChanges();

            ShowSuccesMensage(string.Format("El usuario {0} {1}  se creo con éxito", User.Nombre, User.Apellidos));

            User = new Domain.Entities.User();
           
        }

        void UpdateUser()
        {
            User.Roles.Add(SelectedRole);
            UnitOfWork.UserRepository.Update(User);
            UnitOfWork.SaveChanges();

            ShowSuccesMensage(string.Format("El usuario {0} {1}  se actualizo con éxito", User.Nombre, User.Apellidos));

            User = new Domain.Entities.User();
           
        }
        
        private void SaveUser()
        {
            if (!User.IsValid)
            {
                OnValidationFailed(User);
                return;
            }

            try
            {
                if (User.UserId <= 0)
                {
                    AddUser();
                }
                else
                {
                    UpdateUser();
                }
            }
            catch (Exception e)
            {
                ShowErrorMensage(e.Message);
            }
        }

        private void FindUser()
        {
            CreateDocument("UsersModalView", this);
        }
        
        private async void  SetUser(int id)
        {
            User = await UnitOfWork.UserRepository.FindByIdAsync(id);
            User.ConfirmPassword = User.PasswordHash;
            SelectedRole = User.Roles.FirstOrDefault();

            this.RaisePropertiesChanged();
        }
        
        protected override void OnParameterChanged(object parameter)
        {
            base.OnParameterChanged(parameter);

            if (parameter != null)
            {
                SplashScreenService.ShowSplashScreen();
                SetUser((int)parameter);
                SplashScreenService.HideSplashScreen();
            }
           
        }

        #endregion
    }
}
