using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }

        public ICollection<Ciudad> Cantones { get; set; }
    }
}
