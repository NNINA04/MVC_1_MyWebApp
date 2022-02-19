using System;
using Common.Models;

namespace Common.Interfaces
{
    public interface ISQLVisitInfoRepository
    {
        public Visitor Visitor { get; set; }
        public DateTime Date { get; set; }
    }
}
