using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Vendedor")]
    public class Vendedor: Perfil
    {
        public decimal PresuspuestoAsignado { get; set; }
        
    }
}
