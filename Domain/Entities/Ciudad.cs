using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ciudad
    {
        public int CiudadId { get; set; }

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }
    }
}
