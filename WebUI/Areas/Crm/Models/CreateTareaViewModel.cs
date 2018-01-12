using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Areas.Crm.Models
{
    public class CreateTareaViewModel
    {
        public Tarea Tarea { get; set; }

        public IEnumerable<User> Users { get; set; }
    }

    
}