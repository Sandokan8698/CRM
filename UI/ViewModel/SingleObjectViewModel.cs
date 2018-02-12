using System.ComponentModel;
using System.Linq;
using System.Windows;
using DevExpress.Mvvm;
using Domain.Entities;

namespace UI.ViewModel
{
    public class SingleObjectViewModel<T>: CollectionViewModel where T : BaseEntity<T>, IDataErrorInfo
    {
       
        
        protected void OnValidationFailed(T entity)
        {
            this.RaisePropertiesChanged();
            this.GetService<IMessageBoxService>().Show(entity.Error, "Error de validación", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void CreateDocument(string viewName,  ViewModelBase parent, object viewmodel = null)
        {
            IDocument doc = DocumentManagerService.FindDocument(viewmodel);
            if (doc == null)
            {
                doc = DocumentManagerService.CreateDocument(viewName, viewmodel,parent);
                doc.Id = DocumentManagerService.Documents.Count<IDocument>();
            }
            doc.Show();
        }

    }
}
