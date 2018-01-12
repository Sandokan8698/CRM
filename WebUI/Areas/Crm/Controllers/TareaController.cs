using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Abstract;
using WebUI.Controllers;
using Domain.Entities;
using WebUI.Areas.Crm.Models;

namespace WebUI.Areas.Crm.Controllers
{
    public class TareaController : BaseController
    {
        
        // GET: Crm/Tarea
        public TareaController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ActionResult Index()
        {     
            var tareas = _unitOfWork.TareaRepository.GetAll();
            return View(tareas);
        }
        

        // GET: Crm/Tarea/Create
        public ActionResult Create()
        {
            var TareaVM = new CreateTareaViewModel
            {
                Users =  _unitOfWork.UserRepository.GetAll()
            };
            return View(TareaVM);
        }



        // POST: Crm/Tarea/Create
        [HttpPost]
        public ActionResult Create(Tarea tarea)
        {
            CreateTareaViewModel createTareaVm;
            try
            {
                if (ModelState.IsValid)
                {
                   
                    _unitOfWork.TareaRepository.Add(tarea);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    createTareaVm = new CreateTareaViewModel
                    {
                        Tarea = tarea,
                        Users = _unitOfWork.UserRepository.GetAll()
                    };
                    return View(createTareaVm);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {

                createTareaVm = new CreateTareaViewModel
                {
                    Tarea = tarea,
                    Users = _unitOfWork.UserRepository.GetAll()
                };
                ViewBag.Error = e.Message;
                return View(createTareaVm);
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            var tarea = _unitOfWork.TareaRepository.FindById(id);
            if (tarea == null)
            {
                return  new HttpNotFoundResult();
            }
            return View(tarea);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Tarea tarea)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _unitOfWork.TareaRepository.Update(tarea);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    return View(tarea);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                ViewBag.Error = e.Message;
                return View(tarea);
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            var tarea = _unitOfWork.TareaRepository.FindById(id);
            if (tarea == null)
            {
                return new HttpNotFoundResult();
            }
            return View(tarea);
        }

        // POST: Test/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Tarea tarea = _unitOfWork.TareaRepository.FindById(id);
            try
            {
                if (tarea == null)
                {
                    return  new HttpNotFoundResult();
                }

                _unitOfWork.TareaRepository.Remove(tarea);
                _unitOfWork.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View(tarea);
            }
        }

        public PartialViewResult GetTareaEditView(Tarea tarea)
        {
           
            return PartialView("TareaEditDialog",tarea);
        }

    }
}
