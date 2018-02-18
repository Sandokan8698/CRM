using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ReasignacionHistorial: BaseEntity<ReasignacionHistorial>
    {
        public int ReasignacionHistorialId { get; set; }
        
        public int ReasignadoPorId { get; set; }
        public virtual User ReasignadoPor { get; set; }
        
        public int ReasignadoAId { get; set; }
        public virtual User ReasignadoA { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public DateTime Fecha { get; set; }
    }
}
