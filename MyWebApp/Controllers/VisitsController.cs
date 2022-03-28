using Common.BusinessLogic.GraphComponents;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

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

            var sortedMACAddressWithDateTime = new SortedDataWithDateTime<PhysicalAddress>(allVisitors);

			ViewBag.GraphDataDict = new DateScalingWithCountOfData<PhysicalAddress>(sortedMACAddressWithDateTime).GraphData;

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
