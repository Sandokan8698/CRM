using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using Domain.ChartModels;
using Domain.Entities;
using Domain.Views;
using Sevice;
using UI.View;

namespace UI.ViewModel.Gestion
{
    public class DiasSinGestionarViewModel : ViewModel
    {
        #region Propertys
       
        public List<ViewDiasSinGestionar> DiasSinGestionars
        {
            get { return GetProperty(() => DiasSinGestionars);}
            set { SetProperty(() => DiasSinGestionars, value); }
        }


        public List<DiasSinGestionarSerie> DSGSerieS
        {
            get { return GetProperty(() => DSGSerieS); }
            set { SetProperty(() => DSGSerieS, value); }
        }
        
        
        #endregion

        #region Commands

        public DelegateCommand<ViewDiasSinGestionar> DiasSingestionarChangeCommnad { get; private set; }

        #endregion

        #region Ctor


        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            DiasSinGestionars = new List<ViewDiasSinGestionar>();

            DSGSerieS = new List<DiasSinGestionarSerie>()
            {
                new DiasSinGestionarSerie()
                {
                    DisplayName = "Zapatos",
                    Values =  new List<DiasSingestionarSerieValue>() {
                        new DiasSingestionarSerieValue() { Argument = "Enero", Valor = 5} ,
                        new DiasSingestionarSerieValue() { Argument = "Febrero", Valor = 7} ,
                        new DiasSingestionarSerieValue() { Argument = "Marzo", Valor =4 }
                    }
                }
            };
        }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            DiasSingestionarChangeCommnad = new DelegateCommand<ViewDiasSinGestionar>(OnDiasSinGestionarChange);
        }

        private void OnDiasSinGestionarChange(ViewDiasSinGestionar diasSinGestionar)
        {
            DSGSerieS = UnitOfWork.TareaRepository.SeriesDiasSinGestionar(diasSinGestionar.Id);
        }

        protected override  void OnViewLoaded()
        {
            IsLoading = true;
            DiasSinGestionars =  UnitOfWork.ClienteRepository.DiasSinGestionar(UserManagerService.Instance.CurrentUser.UserId);
            IsLoading = false;
            
        }

        #endregion
    }
}