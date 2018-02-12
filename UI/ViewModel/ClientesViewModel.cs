using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.DemoData.Helpers;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Domain.Entities;

namespace UI.ViewModel
{
    public class ClientesViewModel : CollectionViewModel

    {
        #region Propertys

        public List<Cliente> Clientes
        {
            get { return GetProperty(() => Clientes); }
            set { SetProperty(() => Clientes, value); }
        }

        public Cliente SelectedCliente
        {
            get { return GetProperty(() => SelectedCliente); }
            set { SetProperty(() => SelectedCliente, value); }
        }
        
        #endregion


        #region Commnads

        public DelegateCommand SelectItemCommand { get; private set; }

        #endregion


        #region Ctor

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Clientes = UnitOfWork.ClienteRepository.GetAll();
            SelectItemCommand = new DelegateCommand(SetSelectItem);

        }

        #endregion

        #region Methods

        private void SetSelectItem()
        {
            var parent = this.GetParentViewModel<ViewModelBase>();

            ((ISupportParameter) parent).Parameter = SelectedCliente.ClienteId;

            var document = DocumentManagerService.FindDocument(this);
            document.DestroyOnClose = true;
            document.Close(false);

        }

        #endregion
    }
}
