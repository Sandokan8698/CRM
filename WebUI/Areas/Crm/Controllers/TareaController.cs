using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
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
            var TareaVM = new TareaEditCreateViewModel
            {
                Users =  _unitOfWork.UserRepository.GetAll()
            };
            return View(TareaVM);
        }



        // POST: Crm/Tarea/Create
        [HttpPost]
        public ActionResult Create(Tarea tarea)
        {
            TareaEditCreateViewModel tareaEditCreateVm;
            try
            {
                if (ModelState.IsValid)
                {
                     var history = new TareaHistorial
                     {
                         Tarea = tarea,
                         Descripcion = tarea.Descripcion,
                         TareaEstado = tarea.TareaEstado
                     };
                    _unitOfWork.TareaRepository.Add(tarea);
                    _unitOfWork.TareaHistorialRepository.Add(history);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    tareaEditCreateVm = new TareaEditCreateViewModel
                    {
                        Tarea = tarea,
                        Users = _unitOfWork.UserRepository.GetAll()
                    };
                    return View(tareaEditCreateVm);
                }

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {

                tareaEditCreateVm = new TareaEditCreateViewModel
                {
                    Tarea = tarea,
                    Users = _unitOfWork.UserRepository.GetAll()
                };
                ViewBag.Error = e.Message;
                return View(tareaEditCreateVm);
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

            var viewModel = new TareaEditCreateViewModel
            {
                Tarea = tarea,
                Users = _unitOfWork.UserRepository.GetAll()
            };

            return View(viewModel);
        }

        // POST: Test/Edit/5
        [HttpPost]
        public ActionResult Edit(Tarea tarea)
        {
            var viewModel = new TareaEditCreateViewModel
            {
                Tarea = tarea,
                Users = _unitOfWork.UserRepository.GetAll()
            };

            try
            {
                
                if (ModelState.IsValid)
                {

                    _unitOfWork.TareaRepository.Update(tarea);
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
                return View(viewModel);
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

        public ActionResult ChangeTareaEstado(int tareaId, TareaHistorial tareaHistorial)
        {
            if (ModelState.IsValid && tareaId > 0)
            {
                try
                {
                    tareaHistorial.TareaId = tareaId;
                    var tarea = _unitOfWork.TareaRepository.FindById(tareaId);
                    tarea.TareaEstado = tareaHistorial.TareaEstado;

                    _unitOfWork.TareaRepository.Update(tarea);
                    _unitOfWork.TareaHistorialRepository.Add(tareaHistorial);

                    _unitOfWork.SaveChanges();
                }
                catch (Exception e)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest,e.ToString());
                   
                }

                return PartialView("~/Areas/Crm/Views/Shared/SpanStates.cshtml", tareaHistorial.TareaEstado);
            }

            String messages = String.Join(Environment.NewLine, ModelState.Values.SelectMany(v => v.Errors)
                .Select(v => v.ErrorMessage + " " + v.Exception));

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest,messages);

        }

        public PartialViewResult CreateTareaModals(IEnumerable<Tarea> Tareas)
        {
            var viewModel = new TareaModalsViewModel
            {
                Tareas = Tareas,
                
            };
            return PartialView("~/Areas/Crm/Views/Tarea/TareaModals.cshtml", viewModel);
        }

    }
}
