using System;
using System.Collections.Generic;
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


        public int CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public int AsignadoAId { get; set; }
        public virtual User AsignadoA { get; set; }

        public DateTime Fecha { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        public TipoSeguimiento TipoSeguimiento { get; set; }

        public Tarea()
        {
            Fecha = DateTime.Now;
        }

    }

    public enum TipoSeguimiento
    {
        EnviandoPropuesta,
        LLamando
    }
}
