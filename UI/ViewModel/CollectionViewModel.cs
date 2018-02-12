using System.Windows;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;
using Sevice;

namespace UI.ViewModel
{
    public class CollectionViewModel: ViewModel

    {

        public IUnitOfWork UnitOfWork { get; set; }
        protected  IService Service { get; set; }

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

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            UnitOfWork = new UnitOfWork();
            Service = new Service(UnitOfWork);
        }

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
    }
}
