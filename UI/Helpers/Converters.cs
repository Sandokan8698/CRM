using System;
using System.Collections;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using DevExpress.Data.Helpers;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;

namespace UI.Helpers {
    public class SplitStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value == null ? null : SplitStringHelper.SplitPascalCaseString(value.ToString());
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
    
    public class VisibleColumnsToMarginConverter : MarkupExtension, IValueConverter {
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            IList columns = value as IList;
            if(columns == null) return new Thickness();
            double width = 0;
            foreach(DevExpress.Xpf.Grid.GridColumn column in columns) {
                if(column.CellTemplate == null) break;
                width += column.ActualDataWidth;
            }
            return new Thickness(width, 0, 0, 0);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class DoubleToGridColumnWidthConverter : MarkupExtension, IValueConverter {
        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return new GridColumnWidth((double)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return ((GridColumnWidth)value).Value;
        }
    }

    public class MyEventArgsConverter : EventArgsConverterBase<RoutedEventArgs>
    {
        protected override object Convert(object sender, RoutedEventArgs args)
        {
            return ((ComboBoxEdit)args.Source).SelectedItem;
        }
    }

    public class GridEventArgsConverter : EventArgsConverterBase<RoutedEventArgs>
    {
        protected override object Convert(object sender, RoutedEventArgs args)
        {
            return ((GridControl)args.Source).SelectedItem;
        }
    }
}
