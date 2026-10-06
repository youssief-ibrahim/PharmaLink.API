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
    public class PrescriptionRequestConfiguration : IEntityTypeConfiguration<PrescriptionRequestEntity>
    {
        public void Configure(EntityTypeBuilder<PrescriptionRequestEntity> builder)
        {
            builder.ToTable("PrescriptionRequests", table =>
            {
                table.HasCheckConstraint("CK_PrescriptionRequests_Content",
                    "[ImageUrl] IS NOT NULL OR [MedicineName] IS NOT NULL");
            });
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImageUrl)
                   .HasMaxLength(500);

            builder.Property(x => x.PatientNotes)
                   .HasMaxLength(500);

            builder.Property(x => x.MedicineName)
                   .HasMaxLength(100);

            builder.Property(x => x.Status)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.ExpiresAt)
                   .IsRequired();

            builder.HasOne(x => x.PatientProfile)
                     .WithMany(x => x.PrescriptionRequests)
                     .HasForeignKey(x => x.PatientProfileId)
                     .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.DeliveryAddress)
                        .WithMany(x => x.PrescriptionRequests)
                        .HasForeignKey(x => x.DeliveryAddressId)
                        .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
