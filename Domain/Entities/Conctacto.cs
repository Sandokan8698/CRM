using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contacto: BaseEntity<Contacto>
    {
        public int ContactoId { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Cargo { get; set; }

        [Required]
        [MaxLength(30)]
        public string Celular { get; set; }

        [Required]
        [Column("Date")]
        public DateTime FechaNacimiento  { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Oportunidad> OportunidadesContactoVenta { get; set; }
       
        public Contacto()
        {
            FechaNacimiento = DateTime.Now;
        }
    }
}
