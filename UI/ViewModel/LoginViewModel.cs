using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.DemoData.Helpers;
using DevExpress.Mvvm;
using Sevice;

namespace UI.ViewModel
{
    public class LoginViewModel: CollectionViewModel
    {
        public string UserName
        {
            get { return GetProperty(() => UserName); }
            set { SetProperty(() => UserName, value); }
        }

        public Domain.Entities.User SelectedUser
        {
            get { return GetProperty(() => SelectedUser); }
            set { SetProperty(() => SelectedUser, value); }
        }

        public string Password
        {
            get { return GetProperty(() => Password); }
            set { SetProperty(() => Password, value); }
        }

        public List<Domain.Entities.User> Users
        {
            get { return GetProperty(() => Users); }
            set { SetProperty(() => Users, value); }
        }

        public DelegateCommand LoginCommand { get; set; }


        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Users = UnitOfWork.UserRepository.GetAll();
            LoginCommand = new DelegateCommand(Login,CanLogin);

            Password = "damg";
        }

        void Login()
        {
            if (UserManagerService.Instance.Login(SelectedUser, Password))
            {
                Navigate("GestionView");
            }
        }

        bool CanLogin()
        {
            return SelectedUser != null && Password != null;
        }
    }
}
