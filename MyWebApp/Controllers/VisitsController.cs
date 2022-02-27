using System;
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
        public ViewResult DefinitVisit(int? id)
        {
            return View(id ?? default);
        }
    }
}
