using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Abstract;
using Data.Implementations;
using DevExpress.Mvvm;

namespace UI.Utils
{
    public class CustomViewModel: ViewModelBase
    {
        public IUnitOfWork UnitOfWork { get; set; }

        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();
            UnitOfWork = new UnitOfWork();
            
        }
    }
}
