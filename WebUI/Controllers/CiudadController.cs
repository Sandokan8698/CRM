using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Web.Utils;
using Common.Web.Views;
using Data.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class CiudadController : BaseController
    {
        public CiudadController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        
    }
}