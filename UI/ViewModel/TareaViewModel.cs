using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.DemoData.Helpers;
using DevExpress.Mvvm;
using DevExpress.Xpo;
using Domain.Entities;
using Sevice;

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
        
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Para saber si una gestion de actualizar o crear y asi 
        /// habilitar el campo de cambio de estado
        /// </summary>
        public bool AllowEditEstado
        {
            get
            {
                if (Tarea.TareaId > 0)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion

        #region Commands

        public DelegateCommand SaveTareaCommand { get; set; }

        #endregion

        #region Ctor

       
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
           
            
            Tarea = new Tarea() {TareaEstado = TareaEstado.Activo, TareaTipo = TareaTipo.LLamada};
            SaveTareaCommand = new DelegateCommand(SaveTarea, CanSaveTarea);
        }

        #endregion


        #region Methods

        private void SaveTarea()
        {
            if (!Tarea.IsValid)
            {
                //Esto no va aqui
                if (Tarea.ProximaTarea <= Tarea.Fecha)
                {
                    ShowErrorMensage("Valor de la proxima tarea no valido");
                    return;
                }

                OnValidationFailed(Tarea);
                return;
            }

            try
            {
                if (Tarea.TareaId <= 0)
                {
                    AddTarea();
                }
                else
                {
                    UpdateTarea();
                }
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

        private void AddTarea()
        {
            Tarea.CreadoPorId = UserManagerService.Instance.CurrentUser.UserId;
            Tarea.AsignadoAId = UserManagerService.Instance.CurrentUser.UserId;
            Tarea.ClienteId = Cliente.ClienteId;

              Tarea.Historial.Add(new TareaHistorial()
                {
                    Fecha = DateTime.Now,
                    TareaEstado =  Tarea.TareaEstado,
                    Descripcion =  Tarea.Descripcion
                });

            //El cliente anterior es cargado de otro data context por eso
            //lo vuelvo cargar aqui para q poder realizar la actualizacion 
            //busca otro lugar para esto please
            var elClienteDeTarea = UnitOfWork.ClienteRepository.FindById(Cliente.ClienteId);
            elClienteDeTarea.UltimaGestion = DateTime.Now;

            UnitOfWork.TareaRepository.Add(Tarea);
            UnitOfWork.SaveChanges();

            ShowSuccesMensage(string.Format("La Tarea {0} se creo con éxito", Tarea.Identificador));
            Tarea = new Tarea();
        }

        private void UpdateTarea()
        {
            
            UnitOfWork.TareaRepository.Update(Tarea);
            UnitOfWork.SaveChanges();

            Tarea.Historial.Add(new TareaHistorial()
            {
                Fecha = DateTime.Now,
                TareaEstado = Tarea.TareaEstado,
                Descripcion = Tarea.Descripcion
            });

            //El cliente anterior es cargado de otro data context por eso
            //lo vuelvo cargar aqui para q poder realizar la actualizacion 
            //busca otro lugar para esto please
            var elClienteDeTarea = UnitOfWork.ClienteRepository.FindById(Cliente.ClienteId);
            elClienteDeTarea.UltimaGestion = DateTime.Now;

            ShowSuccesMensage(string.Format("La Tarea {0} se modifico con éxito", Tarea.Identificador));
           
        }

        protected override void OnParameterChanged(object parameter)
        {
            base.OnParameterChanged(parameter);

            if (parameter is Cliente)
            {
                Cliente = parameter as Cliente;
            }

            if (parameter is Tarea)
            {
                var tarea = parameter as Tarea;

                Tarea = UnitOfWork.TareaRepository.FindById(tarea.TareaId);

                if (Tarea != null)
                {
                    Cliente = Tarea.Cliente;
                }

               
            }
            
        }
         
        #endregion

    }

}