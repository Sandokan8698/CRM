using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Abstract;
using Domain.Entities;

namespace WebUI.Areas.Crm.Models
{
    public class OportunidadCreateViewModel
    {
        public Oportunidad Oportunidad { get; set; }

        public IEnumerable<Vendedor> Vendedores { get; set; }
        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<LineaNegocio> LineaNegocios { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
        public IEnumerable<Contacto> ContactosVenta { get; set; }
        public IEnumerable<Contacto> ContactosTomadorDecision { get; set; }
        public IEnumerable<TipoGestion> TipoGestiones { get; set; }

        public OportunidadCreateViewModel()
        {
           
        }

        public OportunidadCreateViewModel(IUnitOfWork unitOfWork)
        {
            Vendedores = unitOfWork.VendedorRepository.GetAll();
            Clientes = unitOfWork.ClienteRepository.GetAll();
            LineaNegocios = unitOfWork.LineaNegocioRepository.GetAll();
            Productos = unitOfWork.ProductoRepository.GetAll();
            ContactosVenta = unitOfWork.ContactoRepository.GetAll();
            ContactosTomadorDecision = ContactosVenta;
            TipoGestiones = unitOfWork.TipoGestionRepository.GetAll();

        }
    }
}