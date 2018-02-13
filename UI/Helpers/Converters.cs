using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Data.Helpers;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Charts;

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






    public class PaletteToBrushConverter : IValueConverter
    {
        public DevExpress.Xpf.Charts.CustomPalette Palette { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = (int)value;
            if (index >= Palette.Count)
                index = 0;
            SolidColorBrush result = new SolidColorBrush(Palette[index]);
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class BillionStringToShortStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string))
                return null;
            string billionFormatString = "0,,.0M";
            string thousandsFormatString = "0,.0K";

            decimal dec;
            bool parsed = decimal.TryParse((string)value, out dec);
            if (parsed)
            {
                if (dec == 0)
                    return "0";
                else if (dec >= 0.1M * 1000000M)
                    return dec.ToString(billionFormatString);
                else
                    return dec.ToString(thousandsFormatString);
            }
            else
                return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
