using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tarea
    {
        public int TareaId { get; set; }


        public int CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public int AsignadoAId { get; set; }
        public virtual User AsignadoA { get; set; }
    }
}
