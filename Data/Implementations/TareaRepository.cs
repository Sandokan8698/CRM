﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Domain.Entities;

namespace Data.Implementations
{
    internal class TareaRepository: Repository<Tarea>, ITareaRepository
    {
        internal TareaRepository(CRMContex context) : base(context)
        {
        }

        
    }
}
