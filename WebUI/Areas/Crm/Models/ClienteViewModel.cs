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

        public IEnumerable<User> Users { get; set; }
    }
}