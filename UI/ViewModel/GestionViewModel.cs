using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Data.Implementations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Domain.Entities;
using UI.Utils;

namespace UI.ViewModel
{
    public class GestionViewModel : SingleObjectViewModel<Cliente>
    {
        #region Propertys
        
        public Cliente Cliente
        {
            get { return GetProperty(() => Cliente); }
            set { SetProperty(() => Cliente, value); }
        }

        public IEnumerable<Provincia> Provincias { get; set; }

        public IEnumerable<Ciudad> Ciuadades
        {
            get { return GetProperty(() => Ciuadades); }
            set { SetProperty(() => Ciuadades, value); }
        }

        
        public Contacto TomadDecision
        {
            get { return GetProperty(() => TomadDecision); }
            set { SetProperty(() => TomadDecision, value); }
        }

        public IEnumerable<Contacto> Contactos
        {
            get { return GetProperty(() => Contactos); }
            set { SetProperty(() => Contactos, value); }
        }

        #endregion

        #region Commands

        public DelegateCommand SaveClienteCommand { get; private set; }
        public DelegateCommand OnProvinciaChangeCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand DeleteClientCommand { get; private set; }

        #endregion

        #region Ctor
        


        protected override void OnInitializeInRuntime()
        {
           
            base.OnInitializeInRuntime();
            Cliente = new Cliente();
            Ciuadades = new List<Ciudad>();
            Provincias = UnitOfWork.ProvinciaRepository.GetAll();
            Contactos = new List<Contacto>() { new Contacto(), new Contacto(), new Contacto() };

            SaveClienteCommand = new DelegateCommand(Save);
            OnProvinciaChangeCommand = new DelegateCommand(OnProvinciaChange);
            FindCommand = new DelegateCommand(Find);
            DeleteClientCommand = new DelegateCommand(DeleteCliente,CanDeleteCliente);
        }

        #endregion


        #region Methods

        private void Save()
        {
            if (!Cliente.IsValid)
            {
                OnValidationFailed(Cliente);
                return;
            }

            try
            {
                if (Cliente.ClienteId <= 0)
                {
                    AddCliente();
                }
                else
                {
                    UpdateCliente();
                }
            }
            catch (Exception e)
            {
                ShowErrorMensage(e.Message);
            }
            
        }


        private void AddCliente()
        {
            UnitOfWork.ClienteRepository.Add(Cliente);
            UnitOfWork.SaveChanges();
            ShowSuccesMensage("El cliente " + Cliente.Nombre + "se creo con éxito.");
            Cliente = new Cliente();
        }

        private void UpdateCliente()
        {
            UnitOfWork.ClienteRepository.Add(Cliente);
            UnitOfWork.SaveChanges();
            ShowSuccesMensage("El cliente " + Cliente.Nombre + "se actualizo con éxito.");
        }

        private void DeleteCliente()
        {
            if (ShowWarningWithResultMesage("El Cliente sera eliminado permanentemente, desea continuar") == MessageBoxResult.OK)
            {
                try
                {
                    UnitOfWork.ClienteRepository.Remove(Cliente);
                    UnitOfWork.SaveChanges();

                    ShowSuccesMensage("El cliente se elimino con éxito");
                }
                catch (Exception e)
                {
                    ShowErrorMensage(e.ToString());
                }
            }
        }

        private bool CanDeleteCliente()
        {
            return Cliente != null;
        }

        private void Find()
        {
            CreateDocument("Clientes",this);
        }

        
        private async void OnProvinciaChange()
        {
            if (Cliente.Provincia != null)
            {
                SplashScreenService.ShowSplashScreen();
                Ciuadades = await UnitOfWork.CiudadRepository.FindAsync(CancellationToken.None, c => c.ProvinciaId == Cliente.Provincia.ProvinciaId);
                SplashScreenService.HideSplashScreen();
            }
            
        }

        private async void  SetCliente(int id)
        {
            Cliente = await UnitOfWork.ClienteRepository.FindByIdAsync(id);
        }

        protected override void OnParameterChanged(object parameter)
        {
            base.OnParameterChanged(parameter);

            if (parameter != null)
            {
                int id = (int)parameter;
                SplashScreenService.ShowSplashScreen();
                SetCliente(id);
                SplashScreenService.HideSplashScreen();
            }
           
        }

        

        #endregion
    }
}