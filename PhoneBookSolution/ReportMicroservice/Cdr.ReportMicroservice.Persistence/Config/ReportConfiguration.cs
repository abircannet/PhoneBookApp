using Cdr.ReportMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cdr.ReportMicroservice.Persistence.Config
{
    public class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports", "dbo");
            builder.HasKey(x => x.Id);
            builder.Property(r => r.RequestTime).IsRequired();
            builder.Property(r => r.ReportStatus).IsRequired();
            builder.Property(r => r.FilePath).HasMaxLength(256).IsRequired(false);
        }
    }
}
