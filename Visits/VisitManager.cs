using System;
using Models;

namespace SiteVisits
{
    public class VisitManager : VisitInfo
    {
        static VisitManager()
        {
            int someValuefromDataBase = new Random().Next(10000);

            VisitsCount = someValuefromDataBase;
        }

        public static int VisitsCount { get; private set; }

        public VisitManager(User user)
        {
            VisitsCount++;
            User = user;
            Date = DateTime.Now;
        }
    }
}
