using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Internal;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Core;
using UI.Helpers;

namespace UI {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            Start(() => base.OnStartup(e));
        }
        public static void Start(Action baseStart) {
            //ExceptionHelper.Initialize();
            //DataDirectoryHelper.SetWebBrowserMode();
            //LoadPlugins();
            ApplicationThemeHelper.ApplicationThemeName = Theme.MetropolisDark.Name;
            baseStart();
            Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(200));
            SetCultureInfo();
        }
//#region LoadPlugins
//        static void LoadPlugins() {
//            foreach(string file in Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "UI.*.exe")) {
//                Assembly plugin = Assembly.LoadFrom(file);
//                if(plugin == null) continue;
//                Type entry = plugin.GetType("Global.Program");
//                if(entry == null) continue;
//                MethodInfo start = entry.GetMethod("Start", BindingFlags.Static | BindingFlags.Public, null, new Type[] { }, null);
//                if(start == null) continue;
//                start.Invoke(null, new object[] { });
//            }
//        }
//#endregion
        static void SetCultureInfo() {
           System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-ES");
        }
    }
}
#if CLICKONCE
    namespace DevExpress.Internal.DemoLauncher {
        public static class ClickOnceEntryPoint {
            public static Window CreateMainWindow() {
                ViewLocator.Default = new ViewLocator(new[] { typeof(UI.App).Assembly });
                Application app = Application.Current;
                app.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = DevExpress.Utils.AssemblyHelper.GetResourceUri(typeof(ClickOnceEntryPoint).Assembly, "Themes/Common.xaml") });
                UI.App.Start(() => { });
                return new UI.View.MainWindow();
            }
        }
    }
#endif
