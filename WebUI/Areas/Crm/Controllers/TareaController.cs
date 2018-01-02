using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Abstract;
using WebUI.Controllers;
using Domain.Entities;

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


            var usuarios = _unitOfWork.UserRepository.GetAll();

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
                   
                    _unitOfWork.TareaRepository.Add(tarea);
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
                
                return View(tarea);
            }
        }




    }
}
