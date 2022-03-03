using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    public class VisitsController : Controller
    {
        protected readonly IVisitorInfoRepository _visitorInfo;

        public VisitsController(IVisitorInfoRepository visitorInfo)
        {
            _visitorInfo = visitorInfo;
        }

        [HttpGet]
        public ViewResult AllVisitors()
        {
            var allVisitors = _visitorInfo.GetAllVisitorInfo();

            return View(allVisitors);
        }

        [HttpGet]
        public ViewResult DefinitVisitor(int id)
        {
            var visitor = _visitorInfo.GetVisitorInfoById(id);

            return View(visitor);
        }
    }
}
