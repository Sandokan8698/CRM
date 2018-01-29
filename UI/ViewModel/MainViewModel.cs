namespace UI.ViewModel {
    public sealed class MainViewModel : ViewModel {
        protected override void OnViewLoaded() {
            base.OnViewLoaded();
            Navigate("ModuleSelectorView");
        }
    }
}
