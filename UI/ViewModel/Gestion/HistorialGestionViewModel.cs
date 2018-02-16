using System.Collections.Generic;
using System.Linq;
using Data.Abstract;
using DevExpress.Mvvm;
using Domain.Entities;

namespace UI.ViewModel.Gestion
{
    public class HistorialGestionViewModel : CollectionViewModel<TareaHistorial>
    {
        protected override IRepository<TareaHistorial> GetRepository()
        {
            return UnitOfWork.TareaHistorialRepository;
        }

        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            Entities = new List<TareaHistorial>();
        }

        protected override void OnParameterChanged(object parameter)
        {
            base.OnParameterChanged(parameter);

            var tarea = parameter as Tarea;

            if (tarea != null)
            {
                Entities = UnitOfWork.TareaHistorialRepository.Find(c => c.TareaId == tarea.TareaId).ToList();
            }

        }
    }
}