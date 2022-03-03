using Microsoft.EntityFrameworkCore;

namespace Common.BusinessLogic.DataBases
{
    public class VisitsDBContext : DbContext
    {
        public DbSet<SQLVisitorInfo> VisitorInfo { get; set; }

        public VisitsDBContext(DbContextOptions<VisitsDBContext> options) : base(options)
        {

        }
    }
}
