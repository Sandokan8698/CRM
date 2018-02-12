using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TomaDescicion: BaseEntity<TomaDescicion>

    {
        public int TomaDescicionId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cargo { get; set; }

        [Required]
        [MaxLength(15)]
        public string Celular { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
