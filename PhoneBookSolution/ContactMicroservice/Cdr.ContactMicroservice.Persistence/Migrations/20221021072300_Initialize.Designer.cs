﻿// <auto-generated />
using System;
using Cdr.ContactMicroservice.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cdr.ContactMicroservice.Persistence.Migrations
{
    [DbContext(typeof(ContactDbContext))]
    [Migration("20221021072300_Initialize")]
    partial class Initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("Id");

                    b.ToTable("Contacts", "dbo");
                });

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.ContactDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("ContactDetailType")
                        .HasColumnType("tinyint");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("ContactDetailType");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactDetails", "dbo");
                });

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.ContactDetail", b =>
                {
                    b.HasOne("Cdr.ContactMicroservice.Domain.Entities.Contact", null)
                        .WithMany("ContactDetails")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.Contact", b =>
                {
                    b.Navigation("ContactDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
