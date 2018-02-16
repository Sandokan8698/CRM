using System.Collections.Generic;
using System.Linq;
using Data.Abstract;
using DevExpress.Mvvm;
using Domain.Entities;
using Sevice;

namespace UI.ViewModel.Gestion
{
    public class DiarioGestionesViewModel : CollectionViewModel<Tarea>
    {
        protected override void OnInitializeInDesignMode()
        {
            base.OnInitializeInDesignMode();
            Entities = new List<Tarea>();
        }

        #region Methods
        protected override IRepository<Tarea> GetRepository()
        {
            return UnitOfWork.TareaRepository;
        }

        protected override void OnViewLoaded()
        {
            Entities = UnitOfWork.TareaRepository
                .Find(c => c.CreadoPor.UserId == UserManagerService.Instance.CurrentUser.UserId).ToList();

        }

        protected override void OnSetSelectItemChange(Tarea entity)
        {
            
        }

        #endregion
    }
}