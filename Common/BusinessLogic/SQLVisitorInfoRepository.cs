using Common.BusinessLogic.DataBases;
using Common.Interfaces;
using Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.BusinessLogic
{
    public class SQLVisitorInfoRepository : IVisitorInfoRepository
    {
        protected VisitsDBContext _context;

        public readonly bool _addingAvailableForToday;

        public SQLVisitorInfoRepository(VisitsDBContext context)
        {
            _context = context;
            AddNewVisitorToDBIfNewForToday();
        }

        public IEnumerable<Visitor> GetAllVisitorInfo()
        {
            return _context.VisitorInfo;
        }

        public SQLVisitorInfo GetVisitorInfoById(int Id)
        {
            return _context.VisitorInfo.FirstOrDefault(x => x.Id == Id);
        }

        private void AddNewVisitorToDBIfNewForToday()
        {
            int newMaxId = 0;
            
            SQLVisitorInfo lastVisitorInfo = _context.VisitorInfo
                .OrderByDescending(x => x.Id).FirstOrDefault();

            if (lastVisitorInfo != default)
                newMaxId = lastVisitorInfo.Id + 1;

            SQLVisitorInfo currentVisitorInfo = new SQLVisitorInfo(newMaxId);

            var allVisitorsWithTheSameMACADDress = _context.VisitorInfo
                .OrderByDescending(x => x.MACAddress.Equals(currentVisitorInfo.MACAddress));

            SQLVisitorInfo visitorInfoFromDB = (from visitor in allVisitorsWithTheSameMACADDress
                                  where visitor.MACAddress == currentVisitorInfo.MACAddress
                                  && visitor.Date.Day == currentVisitorInfo.Date.Day
                                  select visitor).FirstOrDefault();
            if (visitorInfoFromDB == default)
            {
                _context.Add(currentVisitorInfo);
                _context.SaveChanges();
            }
        }
    }
}
