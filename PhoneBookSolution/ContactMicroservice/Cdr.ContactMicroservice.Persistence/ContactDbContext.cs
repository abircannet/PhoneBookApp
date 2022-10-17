﻿using Cdr.ContactMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Persistence
{
    public class ContactDbContext:DbContext
    {
        public ContactDbContext (DbContextOptions<ContactDbContext> options) : base(options) { }
        public DbSet<Contact> Contacts{ get; set; }
        public DbSet<ContactDetail> ContactDetails{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}