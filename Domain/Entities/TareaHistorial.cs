using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TareaHistorial
    {
        public int TareaHistorialId { get; set; }

        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descripcion { get; set; }
        
        public DateTime Fecha { get; set; }

        [DisplayName("Estado")]
        public TareaEstado TareaEstado { get; set; }

        public TareaHistorial()
        {
            Fecha = DateTime.Now;
        }
    }
}
