using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Abstract;
using Domain.Entities;
using WebUI.Controllers;

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
            return View();
        }



        // POST: Crm/Tarea/Create
        [HttpPost]
        public ActionResult Create(Tarea tarea)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tarea.AsignadoA = _unitOfWork.UserRepository.FindById(tarea.AsignadoAId);
                    tarea.CreadoPor = _unitOfWork.UserRepository.FindById(tarea.CreadoPorId);
                    _unitOfWork.TareaRepository.Add(tarea);
                    _unitOfWork.SaveChanges();
                }
                else
                {
                    return View(tarea);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(tarea);
            }
        }




    }
}
