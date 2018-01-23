using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TipoGestion
    {
        public int TipoGestionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
    }
}
