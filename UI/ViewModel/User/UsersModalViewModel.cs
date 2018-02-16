using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace UI.ViewModel.User
{
    public class UsersModalViewModel: CollectionViewModel<Domain.Entities.User>
    {

       
        #region Methods

        protected override void OnSetSelectItemChange(Domain.Entities.User user)
        {
            base.OnSetSelectItemChange(user);

            var document = DocumentManagerService.FindDocument(this);
            document.DestroyOnClose = true;
            document.Close(false);

        }

        protected override IRepository<Domain.Entities.User> GetRepository()
        {
            return UnitOfWork.UserRepository;
        }

        protected override void OnViewLoaded()
        {
            base.OnViewLoaded();
            Entities = Repository.GetAll();
        }

        #endregion
    }
}
