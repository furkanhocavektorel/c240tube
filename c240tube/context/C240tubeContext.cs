using c240tube.entity;
using Microsoft.EntityFrameworkCore;

namespace c240tube.context
{
    public class C240tubeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;database=c240tube;Trusted_Connection=True;TrustServerCertificate=True");
        }

        public DbSet<Auth> Auths { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Streamer> Streamer { get; set; }

    }
}
