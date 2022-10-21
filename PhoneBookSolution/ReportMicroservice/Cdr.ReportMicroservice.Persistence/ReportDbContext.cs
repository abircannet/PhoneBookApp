using Cdr.ReportMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ReportMicroservice.Persistence
{
    public class ReportDbContext:DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> opt):base(opt){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


        public DbSet<Report> Reports{ get; set; }
    }
}
