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

        
        public Guid CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

       
        public Guid AsignadoAId { get; set; }
        public User AsignadoA { get; set; }
    }
}
