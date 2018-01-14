using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Domain.Entities;

namespace WebUI.Areas.Crm.Models
{
    public class TareaEditCreateViewModel
    {
        public Tarea Tarea { get; set; }

        public IEnumerable<User> Users { get; set; }
    }

    public class TareaModalsViewModel
    {
        public TareaHistorial TareaHistorial { get; set; }

        public IEnumerable<Tarea> Tareas;

    }
}