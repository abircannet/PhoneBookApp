﻿// <auto-generated />
using System;
using Cdr.ContactMicroservice.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cdr.ContactMicroservice.Persistence.Migrations
{
    [DbContext(typeof(ContactDbContext))]
    partial class ContactDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ContactsIdentifier");

                    b.ToTable("Contacts", "dbo");
                });

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.ContactDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<byte>("ContactDetailType")
                        .HasColumnType("smallint");

                    b.Property<Guid>("ContactId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)");

                    b.HasKey("Id");

                    b.HasIndex("ContactDetailType");

                    b.HasIndex("ContactId");

                    b.HasIndex("Id")
                        .IsUnique()
                        .HasDatabaseName("ContactDetailsIdentifier");

                    b.ToTable("ContactDetails", "dbo");
                });

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.ContactDetail", b =>
                {
                    b.HasOne("Cdr.ContactMicroservice.Domain.Entities.Contact", "Contact")
                        .WithMany("ContactDetails")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Cdr.ContactMicroservice.Domain.Entities.Contact", b =>
                {
                    b.Navigation("ContactDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
