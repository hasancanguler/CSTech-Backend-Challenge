using Microsoft.EntityFrameworkCore;

namespace ProductDAL
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<StockBalance> StockBalance { get; set; }

    }
}
