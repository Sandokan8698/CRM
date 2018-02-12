using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.DemoData.Helpers;
using DevExpress.Mvvm;
using DevExpress.Xpo;
using Domain.Entities;

namespace UI.ViewModel
{
    public enum ColorState { Red, Green, Yellow }

    public class TareaViewModel : SingleObjectViewModel<Tarea>
    {
        #region Propertys
        public TareaPrioridad TareaPrioridad { get; set; }

        public TareaEstado Estado { get; set; }

        public Tarea Tarea
        {
            get { return GetProperty(() => Tarea); }
            set { SetProperty(() => Tarea, value); }
        }

        public IEnumerable<Tarea> Gestiones
        {
           get { return GetProperty(() => Gestiones); }
           set { SetProperty(() => Gestiones, value); }
        }

        public Cliente Cliente { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SaveTareaCommand { get; set; }

        #endregion

        #region Ctor

        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            Gestiones = new ObservableCollection<Tarea>();
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Gestiones = UnitOfWork.TareaRepository.GetAll();
            
            Tarea = new Tarea() {TareaEstado = TareaEstado.Activo};
            SaveTareaCommand = new DelegateCommand(SaveTarea, CanSaveTarea);
        }

        #endregion


        #region Methods

        private void SaveTarea()
        {
            if (!Tarea.IsValid)
            {
                OnValidationFailed(Tarea);
            }

            try
            {
               
                Tarea.CreadoPorId = 1;
                Tarea.AsignadoAId = 1;
                Tarea.ClienteId = Cliente.ClienteId;

                UnitOfWork.TareaRepository.Add(Tarea);
                UnitOfWork.SaveChanges();

                ShowSuccesMensage(string.Format("La Tarea {0} se creo con éxito",Tarea.Identificador));
                Tarea = new Tarea();
            }
            catch (Exception e)
            {
               ShowErrorMensage(e.Message);
            }
        }

        private bool CanSaveTarea()
        {

            return Cliente == null ? false : Cliente.IsValid;
        }

        protected override void OnParameterChanged(object parameter)
        {
            base.OnParameterChanged(parameter);
            Cliente  = (Cliente)parameter;
        }
         
        #endregion

    }

}