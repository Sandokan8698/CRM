using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Xpf.CodeView;
using Domain.Entities;
using UI.View;

namespace UI.ViewModel.Gestion
{
    public class ReasignacionClienteViewModel : SingleObjectViewModel<ReasignacionHistorial>
    {
        #region Propertys

        public Domain.Entities.User AsignadoFrom
        {
            get { return GetProperty(() => AsignadoFrom); }
            set { SetProperty(() => AsignadoFrom, value); }
        }

        public Domain.Entities.User Asignador
        {
            get { return GetProperty(() => Asignador); }
            set { SetProperty(() => Asignador, value); }
        }

        public List<Domain.Entities.User> Users
        {
            get { return GetProperty(() => Users); }
            set { SetProperty(() => Users, value); }
        }

        public ObservableCollection<Cliente> SelectAsignadorClientes
        {
            get { return GetProperty(() => SelectAsignadorClientes); }
            set { SetProperty(() => SelectAsignadorClientes, value); }
        }

        public ObservableCollection<Cliente> SelectAsignadoFromClientes
        {
            get { return GetProperty(() => SelectAsignadoFromClientes); }
            set { SetProperty(() => SelectAsignadoFromClientes, value); }
        }

        public ObservableCollection<Cliente> AsignadorClientes
        {
            get { return GetProperty(() => AsignadorClientes); }
            set { SetProperty(() => AsignadorClientes, value); }
        }

        public ObservableCollection<Cliente> AsignadoFromClientes
        {
            get { return GetProperty(() => AsignadoFromClientes); }
            set { SetProperty(() => AsignadoFromClientes, value); }
        }

        #endregion

        #region Commands

        public DelegateCommand<Domain.Entities.User> OnAsignadorFromUserChangeCommand { get; private set; }
        public DelegateCommand<Domain.Entities.User> OnAsignadorUserChangeCommand { get; private set; }

        public DelegateCommand MoveFowardCommand { get; set; }
        public DelegateCommand MoveFowardFullCommand { get; set; }
        public DelegateCommand MoveBackwardCommand { get; set; }
        public DelegateCommand MoveBackwardFullCommand { get; set; }

        #endregion

        #region Initializer

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();

            SelectAsignadorClientes = new ObservableCollection<Cliente>();
            SelectAsignadoFromClientes = new ObservableCollection<Cliente>();

            AsignadorClientes = new ObservableCollection<Cliente>();
            AsignadoFromClientes = new ObservableCollection<Cliente>();

            OnAsignadorFromUserChangeCommand = new DelegateCommand<Domain.Entities.User>(OnAsignadorFromUserChange);
            OnAsignadorUserChangeCommand = new DelegateCommand<Domain.Entities.User>(OnAsignadorUserChange);

            MoveFowardCommand = new DelegateCommand(MoveForward,CanMoveForward);
            MoveBackwardCommand = new DelegateCommand(MoveBackward,CanMoveBackward);
            MoveFowardFullCommand = new DelegateCommand(MoveForwardFull,CanMoveForwardFull);
            MoveBackwardFullCommand = new DelegateCommand(MoveBackwardFull,CanMoveBackwardFull);
           
        }
        

        protected override async void OnViewLoaded()
        {
            base.OnViewLoaded();

            SplashScreenService.ShowSplashScreen();
            Users = await UnitOfWork.UserRepository.GetAllAsync();
            SplashScreenService.HideSplashScreen();
        }

        #endregion


        #region Methods

        private  void  OnAsignadorFromUserChange(Domain.Entities.User user)
        {
            IsLoading = true;

             AsignadoFromClientes.Clear();

             UnitOfWork.ClienteRepository.Find( c => c.UserId == user.UserId).ForEach(c =>
             {
                 AsignadoFromClientes.Add(c);
             });

            IsLoading = false;
        }

        private  void OnAsignadorUserChange(Domain.Entities.User user)
        { 
            IsLoading = true;

            AsignadorClientes.Clear();

            UnitOfWork.ClienteRepository.Find(c => c.UserId == user.UserId).ForEach(c =>
            {
                AsignadorClientes.Add(c);
            });


            IsLoading = false;
        }


        private void MoveBackwardFull()
        {
            ReasignarClientes
            (
                AsignadoFromClientes,
                AsignadorClientes,
                AsignadoFromClientes,
                AsignadoFrom,
                Asignador
            );
        }

        private bool CanMoveBackwardFull()
        {
            if (Asignador == null || AsignadoFrom == null)
            {
                return false;
            }

            return Asignador.UserId != AsignadoFrom.UserId;
        }


        private void MoveBackward()
        {
            ReasignarClientes
            (
                SelectAsignadoFromClientes,
                AsignadorClientes,
                AsignadoFromClientes,
                AsignadoFrom,
                Asignador
            );
        }

        private bool CanMoveBackward()
        {
            if (Asignador == null || AsignadoFrom == null)
            {
                return false;
            }

            return SelectAsignadoFromClientes.Count > 0 && Asignador.UserId != AsignadoFrom.UserId;
        }


        private  void MoveForward()
        {
            ReasignarClientes
            (
                SelectAsignadorClientes,
                AsignadoFromClientes,
                AsignadorClientes,
                Asignador,
                AsignadoFrom
            );
        }

        private bool CanMoveForward()
        {
            if (Asignador == null || AsignadoFrom == null)
            {
                return false;
            }

            return SelectAsignadorClientes.Count > 0 && Asignador.UserId != AsignadoFrom.UserId;
        }


        private void MoveForwardFull()
        {
            ReasignarClientes
                (
                   AsignadorClientes,
                   AsignadoFromClientes,
                   AsignadorClientes,
                   Asignador,
                   AsignadoFrom
                );
        }

        private bool CanMoveForwardFull()
        {
            if (Asignador == null || AsignadoFrom == null)
            {
                return false;
            }

           return Asignador.UserId != AsignadoFrom.UserId;
        }


        /// <summary>
        /// Realiza operación de reasignar clientes de uno a otro cliente
        /// </summary>
        /// <param name="listWithValue">Lista que contiene los clientes a actualizar</param>
        /// <param name="listToAdd">Lista a la que se agregan los clientes</param>
        /// <param name="listToRemove">Lista de la que se borran los clientes</param>
        /// <param name="asignador">Asignador de los clientes</param>
        /// <param name="asignadoFrom">A quien se le asingnan los clientes</param>
        private void ReasignarClientes(
            ObservableCollection<Cliente> listWithValue,
            ObservableCollection<Cliente> listToAdd,
            ObservableCollection<Cliente> listToRemove,
            Domain.Entities.User asignador,
            Domain.Entities.User asignadoFrom)
        {
            try
            {
                SplashScreenService.ShowSplashScreen();

                ReasignarClientes(listWithValue, AsignadoFrom);

                UnitOfWork.ReasignacionHistorialRepository.AddAll(GetReasignacionHistorial(listWithValue, asignador, asignadoFrom));
                UnitOfWork.SaveChanges();

                AddAsignados(listToAdd, listWithValue);
                RemoveAsignados(listToRemove, listWithValue);

                SplashScreenService.HideSplashScreen();

                listWithValue.Clear();

                ShowSuccesMensage("El proceso de reasignación se completo con éxito");
            }
            catch (Exception e)
            {
                SplashScreenService.HideSplashScreen();
                ShowErrorMensage(e.Message);
            }
           
        }

        /// <summary>
        /// Cambia los id clientes y les asigna el id de asignarA
        /// </summary>
        /// <param name="clientes">Clientes a actualizar</param>
        /// <param name="asingarA">Usuario al que se le asignan los clientes</param>
        private void ReasignarClientes(ObservableCollection<Cliente> clientes, Domain.Entities.User asingarA)
        {
            foreach (var cliente in clientes)
            {
                cliente.UserId = asingarA.UserId;
            }
        }

        private List<ReasignacionHistorial> GetReasignacionHistorial(ObservableCollection<Cliente> clientes, Domain.Entities.User asignador, Domain.Entities.User asignadoFrom)
        {
            List<ReasignacionHistorial> value = new  List<ReasignacionHistorial>();

            foreach (var cliente in clientes)
            {
                value.Add(new ReasignacionHistorial()
                {
                    ReasignadoPorId = asignador.UserId,
                    ReasignadoAId = asignadoFrom.UserId,
                    Fecha = DateTime.Now,
                    Cliente = cliente
                });
                
            }

            return value;
        }

        private void RemoveAsignados(ObservableCollection<Cliente> listaActualizar, ObservableCollection<Cliente> listaARemover)
        {
            var temp = new List<Cliente>();

            for (int i = 0; i < listaARemover.Count; i++)
            {
                temp.Add(listaARemover[i]);
            }


            for (int i = 0; i < temp.Count; i++)
            {
                listaActualizar.Remove(temp[i]);
            }

        }

        private void AddAsignados(ObservableCollection<Cliente> lisatActualizar, ObservableCollection<Cliente> listaAdd)
        {
            for (int i = 0; i < listaAdd.Count; i++)
            {
                lisatActualizar.Add(listaAdd[i]);
            }
            
        }

        #endregion


    }
}