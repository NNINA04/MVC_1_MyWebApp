using Microsoft.EntityFrameworkCore;
using Models;

namespace DataBases
{
    public class VisitsDBContext : DbContext
    {
        public DbSet<SQLVisitInfo> VisitInfo { get; set; }

        public VisitsDBContext(DbContextOptions<VisitsDBContext> options) : base(options)
        {

        }
    }
}
