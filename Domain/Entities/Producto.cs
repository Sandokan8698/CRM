using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }
    }
}
