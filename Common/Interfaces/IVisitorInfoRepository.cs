using Common.BusinessLogic;
using Common.Models;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IVisitorInfoRepository
    {
        IEnumerable<Visitor> GetAllVisitorInfo();
        SQLVisitorInfo GetVisitorInfoById(int Id);
    }
}
