﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Perfil
    {
        public int PerfilId { get; set; }
        
        public string ImagenUrl { get; set; }

    }
}
