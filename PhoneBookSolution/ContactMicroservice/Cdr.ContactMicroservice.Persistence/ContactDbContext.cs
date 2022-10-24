using Cdr.ContactMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cdr.ContactMicroservice.Persistence
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //for postgre
            //modelBuilder.HasPostgresExtension("uuid-ossp");
        }
    }
}
