using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Vendedor")]
    public class Vendedor: Perfil
    {
        public decimal PresuspuestoAsignado { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
