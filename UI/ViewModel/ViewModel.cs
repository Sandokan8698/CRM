using System.Windows;
using System.Windows.Input;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;
using Sevice;

namespace UI.ViewModel {
    public class ViewModel : ViewModelBase {
        ICommand onViewLoadedCommand;
        ICommand navigateCommand;
       

        public IUnitOfWork UnitOfWork { get; set; }

        protected IService Service { get; set; }

        public bool IsLoading
        {
            get { return GetProperty(() => IsLoading); }
            set { SetProperty(() => IsLoading, value); }
        }

        protected IDocumentManagerService DocumentManagerService
        {
            get { return this.GetService<IDocumentManagerService>(); }
        }

        protected ISplashScreenService SplashScreenService
        {
            get { return GetService<ISplashScreenService>(); }
        }

        public IMessageBoxService MessageBoxService
        {
            get { return GetService<IMessageBoxService>(); }
        }


        public ICommand OnViewLoadedCommand {
            get {
                if(onViewLoadedCommand == null)
                    onViewLoadedCommand = new DelegateCommand(OnViewLoaded);
                return onViewLoadedCommand;
            }
        }
        public ICommand NavigateCommand {
            get {
                if(navigateCommand == null)
                    navigateCommand = new DelegateCommand<string>(Navigate);
                return navigateCommand;
            }
        }
       


        #region Ctor
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();

            UnitOfWork = new UnitOfWork();
            Service = new Service(UnitOfWork);
           
           
        }
        #endregion
        
        
        public void Navigate(string target) {
            NavigationService.Navigate(target, null, this);
        }
        protected INavigationService NavigationService { get { return GetService<INavigationService>(); } }
        protected virtual void OnViewLoaded() { }

        public void ShowErrorMensage(string mensage)
        {
            MessageBoxService.Show(mensage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowSuccesMensage(string mensage)
        {
            MessageBoxService.Show(mensage, "Éxtio", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public MessageBoxResult ShowWarningtMesage(string mesage)
        {
            return MessageBoxService.Show(mesage, "Alerta", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        public MessageBoxResult ShowWarningWithResultMesage(string mesage)
        {
            return MessageBoxService.Show(mesage, "Alerta", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        }
    }
}
