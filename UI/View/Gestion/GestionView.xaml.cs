using System;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;
using Domain.Entities;
using UI.ViewModel;
using UI.ViewModel.Gestion;

namespace UI.View.Gestion
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
