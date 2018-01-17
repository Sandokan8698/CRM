using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }

        // GET: Crm/Cliente/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Crm/Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crm/Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            var viewModel = new ClienteCreateViewModel
            {
                Cliente =  cliente
            };
            try
            {
                if (ModelState.IsValid)
                {
                   _unitOfWork.ClienteRepository.Add(cliente);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    return View(viewModel);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View(cliente);
            }
        }

        // GET: Crm/Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Crm/Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
    }
}
