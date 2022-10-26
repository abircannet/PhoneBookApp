using Cdr.ReportMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cdr.ReportMicroservice.Persistence.Postgre
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.HasPostgresExtension("uuid-ossp");

        }


        public DbSet<Report> Reports { get; set; }
    }
}
