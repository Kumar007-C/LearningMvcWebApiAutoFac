using Microsoft.EntityFrameworkCore;

namespace IntervalAnalyser.DbClasses
{
    public class IntervalContext:DbContext
    {
        public IntervalContext(DbContextOptions<IntervalContext> options):base(options) {   }
        public DbSet<IntervalData> IntervalData { get; set; }
    }
}
