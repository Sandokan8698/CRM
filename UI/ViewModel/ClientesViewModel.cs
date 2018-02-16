using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using DevExpress.DemoData.Helpers;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Domain.Entities;
using Sevice;

namespace UI.ViewModel
{
    public class ClientesViewModel : CollectionViewModel<Cliente>

    {
        
        #region Methods

        protected override IRepository<Cliente> GetRepository()
        {
            return UnitOfWork.ClienteRepository;
        }

        protected override void OnSetSelectItemChange(Cliente cliente)
        {
            base.OnSetSelectItemChange(cliente);

            var document = DocumentManagerService.FindDocument(this);
            document.DestroyOnClose = true;
            document.Close(false);

        }

        protected override void OnViewLoaded()
        {
            Entities = Service.UserClientes(UserManagerService.Instance.CurrentUser.UserId);
        }

        #endregion
    }
}
