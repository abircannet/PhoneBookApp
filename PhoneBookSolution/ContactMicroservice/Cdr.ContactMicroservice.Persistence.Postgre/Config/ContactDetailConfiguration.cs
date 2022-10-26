using Cdr.ContactMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cdr.ContactMicroservice.Persistence.Config.Postgre
{
    internal class ContactDetailConfiguration : IEntityTypeConfiguration<ContactDetail>
    {
        public void Configure(EntityTypeBuilder<ContactDetail> builder)
        {

            builder.ToTable("ContactDetails", "dbo");
            builder.HasKey(x => x.Id);

            #region For Postgre
            //builder.HasIndex(x => x.Id)
            //    .HasName("ContactDetailsIdentifier")
            //    .IsUnique();

            //builder.Property(x => x.Id)
            //   .HasColumnName("Identifier")
            //   .HasColumnType("uuid")
            //   .HasDefaultValueSql("uuid_generate_v4()")
            //   .IsRequired(); 
            #endregion


            builder.Property(x => x.ContactDetailType).IsRequired();
            builder.Property(x => x.Content).IsRequired().HasMaxLength(512);

            builder.HasIndex(x => new { x.ContactId });
            builder.HasIndex(x => x.ContactDetailType);




        }
    }
}
