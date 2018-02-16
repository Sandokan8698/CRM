using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class Cliente: BaseEntity<Cliente>
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
        public string Sector { get; set; }

        [Required]
        [MaxLength(25)]
        [DisplayName("D. del Sector")]
        public string DescripcionSector { get; set; }

        [MaxLength(50)]
        [DisplayName("División")]
        public string Division { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Contacto> Contactos { get; set; }

        public int ProvinciaId { get; set; }
        [Required]
        public virtual Provincia Provincia { get; set; }

        public int CiudadId { get; set; }
        [Required]
        public virtual Ciudad Ciudad  { get; set; }

        public virtual Sendero Sendero { get; set; }
       
        public TiPoCliente TiPoCliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime UltimaGestion { get; set; }

        public virtual ICollection<Tarea> Tareas { get; set; }

        [NotMapped]
        public int DiasSingGesgtionar
        {
            get { return UltimaGestion.Day - DateTime.Now.Day; }
        }

        public ClienteEstado ClienteEstado { get; set; }
       
        public virtual TomaDescicion TomaDescicion  { get; set; }

        public Cliente()
        {
            Contactos = new List<Contacto>();
            FechaNacimiento = DateTime.Now;        
        }
        
    }

    
    public enum TiPoCliente
    {
        Natural,
        Juridico
    }


    public enum ClienteEstado
    {
        Caliente,
        Frío
    }
}
