using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SenderoProducto
    {
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        public int SenderoId { get; set; }
        public Sendero Sendero { get; set; }
    }
}
