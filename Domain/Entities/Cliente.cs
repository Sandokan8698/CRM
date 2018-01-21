using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Ruc { get; set; }

        [Required]
        [MaxLength(10)]
        public string Telefono { get; set; }

        [MaxLength(10)]
        [DisplayName("T. Convencional")]
        public string TelefonoConvencional { get; set; }

        [Required]
        [MaxLength(50)]
        public string Direccion { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }
        
        [Required]
        [Column(TypeName = "Date")]
        [DisplayName("Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [MaxLength(50)]
        public String Nombre { get; set; }

        [Required]
        [MaxLength(25)]
        public string Provincia { get; set; }

        [Required]
        [MaxLength(25)]
        public string Ciudad { get; set; }

        [Required]
        [MaxLength(25)]
        public string Sector { get; set; }

        [Required]
        [MaxLength(25)]
        [DisplayName("D. del Sector")]
        public string DescripcionSector { get; set; }

        [MaxLength(50)]
        [DisplayName("División")]
        public string Division { get; set; }


        public int? VendedorId { get; set; }
        public virtual Vendedor Vendedor { get; set; }

        public virtual ICollection<Contacto> Contactos { get; set; }

        public Cliente()
        {
            Contactos = new List<Contacto>();
            FechaNacimiento = DateTime.Now;
        }
        
    }
}
