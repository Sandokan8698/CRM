using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.model
{
    public class DashboarViewModel
    {
        public IEnumerable<Tarea> Tareas { get; set; }
    }
}