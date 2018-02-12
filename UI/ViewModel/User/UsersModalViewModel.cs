using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace UI.ViewModel.User
{
    public class UsersModalViewModel: CollectionViewModel
    {

        #region Propertys

        public List<Domain.Entities.User> Users
        {
            get { return GetProperty(() => Users); }
            set { SetProperty(() => Users, value); }
        }
        
        #endregion

        #region Command

        public DelegateCommand<Domain.Entities.User> SelectItemCommand { get; private set; }

        #endregion

        #region Ctor

        protected override  void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Users = UnitOfWork.UserRepository.GetAll();
            SelectItemCommand = new DelegateCommand<Domain.Entities.User>(SetSelectItem);
        }
        
        #endregion



        #region Methods

        private void SetSelectItem(Domain.Entities.User user)
        {
            var parent = this.GetParentViewModel<ViewModelBase>();

            ((ISupportParameter)parent).Parameter = user.UserId;

            var document = DocumentManagerService.FindDocument(this);
            document.DestroyOnClose = true;
            document.Close(false);

        }

        #endregion
    }
}
