using System;
using DevExpress.Xpo;
using Domain.Entities;
using UI.Utils;

namespace UI.ViewModel
{
    public enum ColorState { Red, Green, Yellow }

    public class TareaViewModel : SingleObjectViewModel<Tarea>
    {
        public TareaPrioridad TareaPrioridad { get; set; }

        public TareaEstado Estado { get; set; }
       
    }

}