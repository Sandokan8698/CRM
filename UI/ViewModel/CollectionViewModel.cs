using System.Collections.Generic;
using System.Windows;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using Sevice;

namespace UI.ViewModel
{
    public abstract class CollectionViewModel<T> : ViewModel where T : class

    {

        #region Propertys

        public List<T> Entities
        {
            get { return GetProperty(() => Entities); }
            set { SetProperty(() => Entities, value); }
        }

        public T CurrentEntity
        {
            get { return GetProperty(() => CurrentEntity); }
            set { SetProperty(() => CurrentEntity, value); }
        }

        protected IRepository<T> Repository { get; private set; }
        
     
        #endregion

        #region Command

        public DelegateCommand<T> SelectItemCommand { get; private set; }

        #endregion

        #region Ctor
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();

            SelectItemCommand = new DelegateCommand<T>(OnSetSelectItemChange);

            Repository = GetRepository();
           
        }
        #endregion

        #region Methods

        protected virtual void OnSetSelectItemChange(T entity)
        {
            var parent = this.GetParentViewModel<ViewModelBase>();

            ((ISupportParameter)parent).Parameter = entity;

        }

        protected override void OnViewLoaded()
        {
            Entities = Repository.GetAll();
        }

        protected abstract IRepository<T> GetRepository();

        #endregion


    }
}
