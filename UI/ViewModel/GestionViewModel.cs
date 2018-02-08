using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;
using Data.Implementations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using Domain.Entities;
using UI.Utils;

namespace UI.ViewModel
{
    public class GestionViewModel : CustomViewModel<Cliente>
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
                UnitOfWork.ClienteRepository.Add(Cliente);
                UnitOfWork.SaveChanges();
                Cliente = new Cliente();
                ShowSuccesMensage("El cliente " + Cliente.Nombre + "se creo con éxito.");
            }
            catch (Exception e)
            {
                ShowErrorMensage(e.Message);
            }
            
        }


        private void Find()
        {
            
        }

        private bool CanFind()
        {
            return !string.IsNullOrEmpty(Cliente.Ruc);
        }

        public async void OnProvinciaChange()
        {
            if (Cliente.Provincia != null)
            {
                var splashScreenService = GetService<ISplashScreenService>();
                splashScreenService.ShowSplashScreen();
                Ciuadades = await UnitOfWork.CiudadRepository.FindAsync(CancellationToken.None, c => c.ProvinciaId == Cliente.Provincia.ProvinciaId);
                splashScreenService.HideSplashScreen();
            }
            
        }

        #endregion
    }
}