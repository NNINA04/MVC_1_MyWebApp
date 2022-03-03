using Common.BusinessLogic.DataBases;
using Common.Interfaces;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.BusinessLogic
{
    public class SQLVisitorInfoRepository : IVisitorInfoRepository
    {
        protected VisitsDBContext _context;

        public SQLVisitorInfoRepository(VisitsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Visitor> GetAllVisitorInfo()
        {
            return _context.VisitorInfo;
        }

        public SQLVisitorInfo GetVisitorInfoById(int Id)
        {
            //return _context.VisitorInfo.ElementAtOrDefault(Id);
            return default;
        }
    }
}
