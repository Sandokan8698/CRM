using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Data.Implementations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using Domain.Entities;
using Sevice;

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


        public TomaDescicion TomaDescicion
        {
            get { return GetProperty(() => TomaDescicion); }
            set { SetProperty(() => TomaDescicion, value); }
        }

        public ObservableCollection<Contacto> Contactos
        {
            get { return GetProperty(() => Contactos); }
            set { SetProperty(() => Contactos, value); }
        }

        public ObservableCollection<Producto> ProductosSendero
        {
            get { return GetProperty(() => ProductosSendero); }
            set { SetProperty(() => ProductosSendero, value); }
        }

        #endregion

        #region Commands

        public DelegateCommand SaveClienteCommand { get; private set; }
        public DelegateCommand OnProvinciaChangeCommand { get; private set; }
        public DelegateCommand FindCommand { get; private set; }
        public DelegateCommand DeleteClientCommand { get; private set; }
        public DelegateCommand NewClienteCommand { get; private set; }

        #endregion

        #region Ctor



        protected override void OnInitializeInRuntime()
        {

            base.OnInitializeInRuntime();
            Cliente = new Cliente();
            Ciuadades = new List<Ciudad>();
            Provincias = UnitOfWork.ProvinciaRepository.GetAll();
            Contactos = new ObservableCollection<Contacto>();
            TomaDescicion = new TomaDescicion();
            ProductosSendero = new ObservableCollection<Producto>();

            SaveClienteCommand = new DelegateCommand(Save);
            OnProvinciaChangeCommand = new DelegateCommand(OnProvinciaChange);
            FindCommand = new DelegateCommand(FindCliente);
            NewClienteCommand = new DelegateCommand(NewCliente);
            DeleteClientCommand = new DelegateCommand(DeleteCliente, CanDeleteCliente);
        }


        #endregion
        
        #region Methods

        private void NewCliente()
        {
            Cliente = new Cliente();
            TomaDescicion = new TomaDescicion();
            Contactos = new ObservableCollection<Contacto>();
        }
        
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
                    ActualizeTomaDescicion();
                    AddCliente();
                }
                else
                {
                    ActualizeTomaDescicion();
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
            Cliente.Contactos = Contactos;
            Cliente.User = UserManagerService.Instance.UserInContext(UnitOfWork);
           
            ProductosSendero.ForEach(ps =>
            {
                Cliente.Sendero.SenderoProducto.Add(new SenderoProducto()
                {
                    Producto =  ps
                });
            });
            

            UnitOfWork.ClienteRepository.Add(Cliente);
            UnitOfWork.SaveChanges();

            ShowSuccesMensage("El cliente " + Cliente.Nombre + "se creo con éxito.");

            Cliente = new Cliente();
            TomaDescicion = new TomaDescicion();
            Contactos = new ObservableCollection<Contacto>();
            ProductosSendero = new ObservableCollection<Producto>();
        }

        private void UpdateCliente()
        {
            Contactos.ForEach(c => c.ClienteId = Cliente.ClienteId);

           
          
            UnitOfWork.ClienteRepository.UpdateRelated(
                Contactos,
                c => c.ClienteId == Cliente.ClienteId,
                c => c.ContactoId);

            UnitOfWork.ClienteRepository.Update(Cliente);
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
                    Cliente = new Cliente();
                    TomaDescicion = new TomaDescicion();
                }
                catch (Exception e)
                {
                    ShowErrorMensage(e.ToString());
                }
            }
        }

        private bool CanDeleteCliente()
        {
            return Cliente.ClienteId > 0;
        }

        private void FindCliente()
        {
            CreateDocument("Clientes", this);
        }

        private async void SetCliente(int id)
        {
            Cliente = await UnitOfWork.ClienteRepository.FindByIdAsync(id);
            TomaDescicion = Cliente.TomaDescicion;
            Contactos.Clear();
            Cliente.Contactos.ForEach(c =>
            {
               Contactos.Add(c);
            });
        }

        private void ActualizeTomaDescicion()
        {
            if (TomaDescicion.TomaDescicionId <= 0)
            {
                AddTomadorDescicion();
            }
            else
            {
                UpdateTomadorDescicion();
            }
        }

        private void AddTomadorDescicion()
        {
            if (!TomaDescicion.IsValid)
            {
                TomaDescicion.Cliente = Cliente;
                string error = "Toma Descición" + Environment.NewLine + TomaDescicion.Error;
                this.RaisePropertiesChanged();
                throw new Exception(error);
            }

            UnitOfWork.TomaDescicionRepository.Add(TomaDescicion);

        }

        private void UpdateTomadorDescicion()
        {
            if (!TomaDescicion.IsValid)
            {
                TomaDescicion.Cliente = Cliente;
                this.RaisePropertyChanged();
                string error = "Toma Descición" + Environment.NewLine + TomaDescicion.Error;
                throw new Exception(error);
            }

            UnitOfWork.TomaDescicionRepository.Update(TomaDescicion);

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