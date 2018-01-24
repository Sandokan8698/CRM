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
    public class Oportunidad
    {
        public int OportunidadId { get; set; }

        [Required]
        [MaxLength(100)]
       
        public string Nombre { get; set; }
        
        public int AsesorId { get; set; }
        public Vendedor Asesor { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        public TipoCartera TipoCartera { get; set; }

        public int LineaNegocioId { get; set; }
        public LineaNegocio LineaNegocio { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [DisplayName("Precio de Venta Unitario")]
        public decimal PVU { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [DisplayName("Precio de Venta Unitario")]
        public decimal Potencial { get; set; }

        public int EtapaId { get; set; }
        public Etapa Etapa { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal ExpectativaVenta { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal ExpectativaAsesor { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime FechaPrevistaCierre { get; set; }

        public int ContactoVentaId { get; set; }
        public Contacto ContactoVenta { get; set; }

        public int TomadorDescicionId { get; set; }
        public Contacto TomadorDesicion { get; set; }

        public int TipoGestionId { get; set; }
        public TipoGestion TipoGestion { get; set; }

    }

    public enum TipoCartera
    {
        Nuevo,
        Actual,
        Recuperado
           
    }
}
