using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using Domain.Entities;
using UI.ViewModel;

namespace UI.View
{
    /// <summary>
    /// Interaction logic for GestionView.xaml
    /// </summary>
    public partial class GestionView : UserControl
    {
        public GestionView()
        {
            InitializeComponent();
        }


        private void GridViewBase_OnValidateRow(object sender, GridRowValidationEventArgs e)
        {
            if (e.Row == null) return;

            if (e.RowHandle == GridControl.NewItemRowHandle)
            {

                Contacto contacto = (Contacto)e.Row;
                e.IsValid = contacto.IsValid;
                e.Handled = true;

            }

        }

        private void GridViewBase_OnInvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            if (e.RowHandle == GridControl.NewItemRowHandle)
            {
                var viewMoel = (GestionViewModel)DataContext;

                Contacto contacto = (Contacto)e.Row;
                viewMoel.ShowErrorMensage("Contacto" + Environment.NewLine + contacto.Error);
               
            }
        }



    }
}
