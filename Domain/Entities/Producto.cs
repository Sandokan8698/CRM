using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        public virtual ICollection<SenderoProducto> SenderoProducto { get; set; }

        public Producto()
        {
            SenderoProducto = new HashSet<SenderoProducto>();
        }
       
    }
}
