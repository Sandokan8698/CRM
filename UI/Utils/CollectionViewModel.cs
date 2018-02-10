using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;

namespace UI.Utils
{
    public class CollectionViewModel: ViewModelBase

    {

        public IUnitOfWork UnitOfWork { get; set; }

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

        }

        protected void ShowErrorMensage(string mensage)
        {
            MessageBoxService.Show(mensage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void ShowSuccesMensage(string mensage)
        {
            MessageBoxService.Show(mensage, "Éxtio", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected MessageBoxResult ShowWarningWithResultMesage(string mesage)
        {
            return MessageBoxService.Show(mesage, "Alerta", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }
    }
}
