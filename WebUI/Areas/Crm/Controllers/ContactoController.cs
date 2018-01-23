using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Common.Web.Utils;
using Common.Web.Views;
using Data.Abstract;
using Domain.Entities;
using WebUI.Controllers;

namespace WebUI.Areas.Crm.Controllers
{
    public class ContactoController : BaseController
    {
        // GET: Crm/Cliente
        public ContactoController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpPost]
        public ActionResult Create(int id, Contacto contacto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    contacto.ClienteId = id;
                    _unitOfWork.ContactoRepository.Add(contacto);
                    _unitOfWork.SaveChanges();

                    return PartialView("ContactoRowPartialView", contacto);

                }

                throw new Exception(MvcGeneralHelper.GetModelStateErrors(ModelState));

            }
            catch (Exception e)
            {
                return new JsonBadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contacto = _unitOfWork.ContactoRepository.FindById(id);
                    if (contacto == null)
                        return HttpNotFound();

                    _unitOfWork.ContactoRepository.Remove(contacto);
                    _unitOfWork.SaveChanges();

                    return Json(new { id = id }, JsonRequestBehavior.AllowGet);

                }

                throw new Exception(MvcGeneralHelper.GetModelStateErrors(ModelState));

            }
            catch (Exception e)
            {
                return new JsonBadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(int clienteId, Contacto contacto)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                     contacto.ClienteId = clienteId;
                    _unitOfWork.ContactoRepository.Update(contacto);
                    _unitOfWork.SaveChanges();

                    return Json(new {
                        id = contacto.ContactoId,
                        view = MvcGeneralHelper.RenderViewToString( this.ControllerContext,"ContactoRowPartialView", contacto,true)},
                        JsonRequestBehavior.AllowGet);
                }

                throw new Exception(MvcGeneralHelper.GetModelStateErrors(ModelState));
            }
            catch (Exception e)
            {
                return new JsonBadRequest(e.Message);
            }
        }

       
    }
}