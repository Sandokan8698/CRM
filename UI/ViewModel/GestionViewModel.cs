using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;
using Data.Implementations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using Domain.Entities;
using UI.Utils;

namespace UI.ViewModel
{
    public class GestionViewModel : CustomViewModel
    {
        public Cliente Cliente
        {
            get { return GetProperty(() => Cliente); }
            set { SetProperty(() => Cliente,value); }
        }

        public IEnumerable<Provincia> Provincias { get; set;}

        public IEnumerable<Ciudad> Ciuadades
        {
            get { return GetProperty(() => Ciuadades); }
            set { SetProperty(() => Ciuadades, value); }
        }

        public Provincia SelectedProvincia
        {
            get { return GetProperty(() => SelectedProvincia); }
            set { SetProperty(() => SelectedProvincia, value, (() => OnProvinciaChange(value))); }
        }

       
        public async void OnProvinciaChange(Provincia provincia)
        {
            Cliente.Provincia = provincia;
            var splashScreenService = GetService<ISplashScreenService>();
            splashScreenService.ShowSplashScreen();
            Ciuadades = await UnitOfWork.CiudadRepository.FindAsync(CancellationToken.None,  c => c.ProvinciaId == provincia.ProvinciaId);
            splashScreenService.HideSplashScreen();
        }

        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            Ciuadades = new List<Ciudad>(){new Ciudad()};
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            Cliente = new Cliente();
            Ciuadades = new List<Ciudad>();
            Provincias = UnitOfWork.ProvinciaRepository.GetAll();
        }
    }
}