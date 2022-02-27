using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class VisitsController : Controller
    {
        [HttpGet]
        public ViewResult AllVisits()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ViewResult DefinitVisit(int id)
        {
            ViewBag.Id = id;

            return View();
        }
    }
}
