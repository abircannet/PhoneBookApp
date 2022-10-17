﻿using Cdr.ContactMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Persistence.Config
{
    internal class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts", "dbo");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                .HasName("ContactsIdentifier")
                .IsUnique();

            //builder.Property(x => x.Id)
            //   .HasColumnName("Identifier")
            //   .HasColumnType("uuid")
            //   .HasDefaultValueSql("uuid_generate_v4()")   
            //   .IsRequired();



            builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(64);
            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(256);

            var navigation = builder.Metadata.FindNavigation(nameof(Contact.ContactDetails));
            navigation?.SetPropertyAccessMode(PropertyAccessMode.Field);

            //builder.HasMany(x => x.ContactDetails).WithOne(x => x.Contact).HasForeignKey(x => x.ContactId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
