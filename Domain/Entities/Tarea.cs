using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tarea
    {
        public int TareaId { get; set; }

        [DisplayName("Creado Por")]
        public int CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        [DisplayName("Asignado A")]
        public int AsignadoAId { get; set; }
        public virtual User AsignadoA { get; set; }

        public DateTime Fecha { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        [DisplayName("Estado")]
        public TareaEstado TareaEstado { get; set; }

        [DisplayName("Fecha Cumplimiento")]
        public DateTime FechaCumplimiento  { get; set; }  

        public Tarea()
        {
            Fecha = DateTime.Now;
        }

    }

    public enum TareaEstado
    {
        Activo,
        Cancelada,
        Cumplida,
        Retrasada
    }
}
