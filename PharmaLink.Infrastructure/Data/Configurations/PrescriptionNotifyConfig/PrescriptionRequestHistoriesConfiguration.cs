using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaLink.Domain.Entities.Pharma_Requests;

namespace PharmaLink.Infrastructure.Data.Configurations.PrescriptionNotifyConfig
{
    public class PrescriptionRequestHistoriesConfiguration : IEntityTypeConfiguration<PrescriptionRequestHistory>
    {
        public void Configure(EntityTypeBuilder<PrescriptionRequestHistory> builder)
        {
            builder.ToTable("PrescriptionRequestHistories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.NewStatus)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.OldStatus)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(x => x.ChangedAt)
                   .IsRequired();

            builder.HasOne(x => x.PrescriptionRequest)
                     .WithMany(x => x.PrescriptionRequestHistorys)
                     .HasForeignKey(x => x.PrescriptionRequestId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ChangedBy)
                     .WithMany()
                     .HasForeignKey(x => x.ChangedById)
                     .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
