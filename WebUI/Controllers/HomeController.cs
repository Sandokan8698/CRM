using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Abstract;
using Data.Implementations;
using Microsoft.AspNet.Identity;
using WebUI.model;

namespace WebUI.Controllers
{
   
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [Authorize]
        public ActionResult Index()
        {
            var viewModel = new DashboarViewModel
            {
                Tareas = _unitOfWork.TareaRepository.GetAll().OrderByDescending(t => t.Fecha).Take(5)
            };

            return View("DashBoard", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult GetUserToBarCredential()
        {
            //Esto esta mal averigual pq el control hace dispose antes de
            //llamar a este metodo
            var uw = new UnitOfWork();

            var user = uw.UserRepository.FindByUserName(HttpContext.User.Identity.Name);
            return PartialView("UserTopBarCredential", user);


        }
    }
}