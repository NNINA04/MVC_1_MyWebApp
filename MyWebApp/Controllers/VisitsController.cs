using System;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class VisitsController : Controller
    {
        public ViewResult Default() 
        {
            return View();
        }

        public ViewResult AllVisits() 
        {
            throw new NotImplementedException();
        }

        public ViewResult DefinitVisit(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
