using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Abstract;
using WebUI.Areas.Crm.Models;
using WebUI.Controllers;

namespace WebUI.Areas.Crm.Controllers
{
    public class OportunidadController : BaseController
    {
        public OportunidadController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public ActionResult Create()
        {
            OportunidadCreateViewModel viewModel = new OportunidadCreateViewModel(_unitOfWork);
            return View(viewModel);
        }
    }
}