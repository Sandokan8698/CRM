﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Gerencia")]
    public class Gerencia: Perfil
    {
        public int Nuevo { get; set; }
    }
}
