using DevExpress.Xpf.Core;

namespace DUI.View {
    public partial class MainWindow : DXWindow {
        public MainWindow() {
            InitializeComponent();
            DevExpress.Utils.About.UAlgo.Default.DoEventObject(DevExpress.Utils.About.UAlgo.kDemo, DevExpress.Utils.About.UAlgo.pWPF, this);
        }
    }
}
