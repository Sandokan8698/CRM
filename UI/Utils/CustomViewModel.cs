using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;
using Domain.Entities;

namespace UI.Utils
{
    public class CustomViewModel<T>: ViewModelBase where T : BaseEntity<T>, IDataErrorInfo
    {
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            UnitOfWork = new UnitOfWork();
            
        }
        
        
        protected void OnValidationFailed(T entity)
        {
            this.RaisePropertiesChanged();
            this.GetService<IMessageBoxService>().Show(entity.Error, "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void ShowErrorMensage(string mensage)
        {
            GetService<IMessageBoxService>().Show(mensage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        protected void ShowSuccesMensage(string mensage)
        {
            GetService<IMessageBoxService>().Show(mensage, "Éxtio", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
