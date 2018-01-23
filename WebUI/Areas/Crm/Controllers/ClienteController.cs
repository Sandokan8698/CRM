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
using WebUI.Areas.Crm.Models;
using WebUI.Controllers;

namespace WebUI.Areas.Crm.Controllers
{
    public class ClienteController : BaseController
    {
        // GET: Crm/Cliente
        public ClienteController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ActionResult Index()
        {
            var clientes = _unitOfWork.ClienteRepository.GetAll();
            return View(clientes);
        }

        // GET: Crm/Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Crm/Cliente/Create
        public ActionResult Create()
        {
            ClienteCreateViewModel viewModel = new ClienteCreateViewModel
            {
                Provincias = _unitOfWork.ProvinciaRepository.GetAll(),
                Ciudadades = _unitOfWork.CiudadRepository.Find(c => c.ProvinciaId == 1)
            };
            return View(viewModel);
        }

        // POST: Crm/Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteCreateViewModel viewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.ClienteRepository.Add(viewModel.Cliente);
                    _unitOfWork.SaveChanges();

                    return RedirectToAction("Edit", new { id = viewModel.Cliente.ClienteId });
                }

                viewModel.Provincias = _unitOfWork.ProvinciaRepository.GetAll();
                viewModel.Ciudadades = _unitOfWork.CiudadRepository
                    .Find(c => c.ProvinciaId == viewModel.Cliente.ProvinciaId);

                return View(viewModel);

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(viewModel);
            }
        }

        // GET: Crm/Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _unitOfWork.ClienteRepository.FindById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ClienteCreateViewModel
            {
                Cliente = cliente,
                Provincias = _unitOfWork.ProvinciaRepository.GetAll(),
                Ciudadades = _unitOfWork.CiudadRepository.Find(c => c.ProvinciaId == 1),
            };

            return View(viewModel);
        }

        // POST: Crm/Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(ClienteCreateViewModel viewModel)
        {
            viewModel.Provincias = _unitOfWork.ProvinciaRepository.GetAll();
            viewModel.Ciudadades = _unitOfWork.CiudadRepository
                .Find(c => c.ProvinciaId == viewModel.Cliente.ProvinciaId);

            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.ClienteRepository.Update(viewModel.Cliente);
                    _unitOfWork.SaveChanges();

                    ViewBag.Success = "El cliente se actualizo correctamente";
                    return RedirectToAction("Edit", new { id = viewModel.Cliente.ClienteId });
                }
                
                return View(viewModel);

            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(viewModel);
            }
        }

        // GET: Crm/Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Crm/Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult GetCiudadByProvincia(int provicinciaId)
        {
            try
            {
                var ciudades = _unitOfWork.CiudadRepository.Find(c => c.ProvinciaId == provicinciaId);
                var viewModel = new ClienteCreateViewModel { Ciudadades = ciudades };
                return Json(MvcGeneralHelper.RenderViewToString(this.ControllerContext, "CiudadDropDownPartialView", viewModel, true),
                    JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return new JsonBadRequest(e.Message);
            }
        }

    }
}
