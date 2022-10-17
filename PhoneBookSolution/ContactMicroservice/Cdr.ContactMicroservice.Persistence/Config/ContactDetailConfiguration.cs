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
    internal class ContactDetailConfiguration : IEntityTypeConfiguration<ContactDetail>
    {
        public void Configure(EntityTypeBuilder<ContactDetail> builder)
        {
            
            builder.ToTable("ContactDetails", "dbo");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id)
                .HasName("ContactDetailsIdentifier")
                .IsUnique();

            //builder.Property(x => x.Id)
            //   .HasColumnName("Identifier")
            //   .HasColumnType("uuid")
            //   .HasDefaultValueSql("uuid_generate_v4()")
            //   .IsRequired();

            builder.Property(x => x.ContactDetailType).IsRequired();
            builder.Property(x => x.Content).IsRequired().HasMaxLength(512); 

            builder.HasIndex(x => new { x.ContactId});
            builder.HasIndex(x => x.ContactDetailType);

            builder.HasOne(x => x.Contact).WithMany(x => x.ContactDetails).HasForeignKey(x => x.ContactId);



        }
    }
}