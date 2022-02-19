using System;
using Common.Interfaces;
using Common.Models;

namespace Common.BusinessLogic
{
    public class SQLVisitInfo : VisitInfo, ISQLVisitInfoRepository
    {
        private static int _id = 0;

        public SQLVisitInfo()
        {
            Visitor = new Visitor
            {
                Id = _id++
            };
            Date = DateTime.Now;
        }
    }
}