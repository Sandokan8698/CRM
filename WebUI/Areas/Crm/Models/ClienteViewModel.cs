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

        public IEnumerable<Provincia> Provincias { get; set; }

        public IEnumerable<Ciudad> Ciudadades { get; set; }

        public IEnumerable<User> Users { get; set; }
        

        public ClienteCreateViewModel()
        {
            Cliente = new Cliente();
            Contacto = new Contacto();
            Users = new List<User>();
            Provincias = new List<Provincia>();
            Ciudadades = new List<Ciudad>();
        }
    }

    public class ClienteContactoViewModel
    {
        public Cliente Cliente { get; set; }

        public Contacto Contacto { get; set; }

        public ClienteContactoViewModel()
        {
            Cliente = new Cliente();
            Contacto = new Contacto();
        }
    }
}