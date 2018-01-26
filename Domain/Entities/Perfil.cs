using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public abstract class Perfil
    {
        public int PerfilId { get; set; }
        
        public string ImagenUrl { get; set; }

        [MaxLength(15)]
        public string Ocupacion { get; set; }

        [MaxLength(15)]
        public string Nombre { get; set; }

        [MaxLength(15)]
        public string Apellidos { get; set; }

        protected Perfil()
        {
            ImagenUrl = "http://localhost:50745/img/user/no-image.png";
            Nombre = "Invintado";
            Ocupacion = "Cambiar Perfil";
        }
    }
}
