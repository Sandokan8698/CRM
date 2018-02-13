using System.Collections.Generic;
using System.Windows;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Sevice;

namespace UI.ViewModel
{
    public class CollectionViewModel<T>: ViewModel where T: class

    {

        #region Propertys

        public List<T> Entities
        {
            get { return GetProperty(() => Entities); }
            set { SetProperty(() => Entities, value); }
        }
       

        public IUnitOfWork UnitOfWork { get; set; }
        protected  IService Service { get; set; }

        public bool IsLoading
        {
            get { return GetProperty(() => IsLoading); }
            set { SetProperty(() => IsLoading, value); }
        }

        protected IDocumentManagerService DocumentManagerService
        {
            get { return this.GetService<IDocumentManagerService>();}
        }

        protected ISplashScreenService SplashScreenService
        {
            get { return GetService<ISplashScreenService>(); }
        }

        public IMessageBoxService MessageBoxService
        {
            get { return GetService<IMessageBoxService>(); }
        }

        #endregion

        #region Command

        public DelegateCommand<T> SelectItemCommand { get; private set; }

        #endregion

        #region Ctor
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            UnitOfWork = new UnitOfWork();
            Service = new Service(UnitOfWork);
            SelectItemCommand = new DelegateCommand<T>(SetSelectItem);
        }
        #endregion

        #region Methods

        public void ShowErrorMensage(string mensage)
        {
            MessageBoxService.Show(mensage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowSuccesMensage(string mensage)
        {
            MessageBoxService.Show(mensage, "Éxtio", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult ShowWarningWithResultMesage(string mesage)
        {
            return MessageBoxService.Show(mesage, "Alerta", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }

        protected virtual void SetSelectItem(T entity)
        {
            var parent = this.GetParentViewModel<ViewModelBase>();

            ((ISupportParameter)parent).Parameter = entity;
            
        }

        #endregion


    }
}
