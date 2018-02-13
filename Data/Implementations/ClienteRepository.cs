using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Data.Abstract;
using Domain.Entities;
using Domain.Views;

namespace Data.Implementations
{
    internal class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        internal ClienteRepository(CRMContex context) : base(context)
        {
        }

        public List<ViewDiasSinGestionar> DiasSinGestionar(int userId)
        {
            var query = Set.Where(c => c.UserId == userId).Select( c => new ViewDiasSinGestionar 
            {
               DiasSingestionar = DateTime.Now.Day - c.UltimaGestion.Day,
               PorcientoGestion = c.Tareas.Count * 100 / c.User.TareasCreadas.Count, 
               Id = c.ClienteId,
               Nombre = c.Nombre,

            }).ToList();

            return query;
        }
    }
}