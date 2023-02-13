using Microsoft.EntityFrameworkCore;
using EmpCompute.Entity;
using Microsoft.Extensions.Configuration;

namespace EmpCompute
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        /*   protected override void OnConfiguring(DbContextOptionsBuilder options)
          {
              // connect to postgres with connection string from app settings
              options.UseNpgsql("Username=postgres;Password=root;Host=localhost;Port=5432;Database=paycompute;");
          } */
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaxYear> TaxYears { get; set; }
    }

}

