using Microsoft.EntityFrameworkCore;
using WAAL.Domain.Entities;
using WAAL.Persistence.Configuration;

namespace WAAL.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CongKetNoi> congKetNois { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ChiTietCongKetNoiConfig());
        }
    }
}
