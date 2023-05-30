using Microsoft.EntityFrameworkCore;

namespace Solution_1.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opts) : base(opts){}

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Solution> Solutions { get; set;}
    }
}
