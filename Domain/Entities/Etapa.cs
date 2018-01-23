using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Etapa
    {
        public int EtapaId { get; set; }

        public int Porciento { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
