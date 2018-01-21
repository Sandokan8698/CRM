using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Areas.Crm.Models
{
    public class ClienteCreateViewModel
    {
        public Cliente Cliente { get; set; }

        public Contacto Contacto { get; set; }

        public IEnumerable<Contacto> Contactos { get; set; }

        public IEnumerable<User> Users { get; set; }

        public ClienteCreateViewModel()
        {
            Cliente = new Cliente();
            Contacto = new Contacto();
            Contactos = new List<Contacto>();
            Users = new List<User>();
        }
    }

    public class ClienteContactoViewModel
    {
        public Cliente Cliente { get; set; }

        public Contacto Contacto { get; set; }
    }
}