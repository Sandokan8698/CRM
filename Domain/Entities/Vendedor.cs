using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Vendedor")]
    public class Vendedor: User
    {
        public virtual ICollection<Tarea> TareasAsignadas { get; set; }
    }
}
