using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Sendero: BaseEntity<Sendero>
    {
        public int SenderoId { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<SenderoProducto> SenderoProducto { get; set; }

        public Sendero()
        {
            SenderoProducto = new HashSet<SenderoProducto>();
        }
    }
}
