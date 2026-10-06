using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaLink.Domain.Entities.Pharma_Requests;

namespace PharmaLink.Infrastructure.Data.Configurations.Pharma_Operations
{
    public class PharmaPerformSnapshotConfiguration : IEntityTypeConfiguration<PharmaPerformSnapshot>
    {
        public void Configure(EntityTypeBuilder<PharmaPerformSnapshot> builder)
        {
            builder.ToTable("PharmaPerformSnapshots");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PeriodStart)
                .IsRequired();

            builder.Property(x => x.PeriodEnd)
                .IsRequired();

            builder.Property(x => x.PeriodType)
               .HasConversion<string>()
               .HasMaxLength(50);

            builder.Property(x => x.TotalBids)
                .IsRequired();

            builder.Property(x => x.WonOrders)
                .IsRequired();

            builder.Property(x => x.CompletedOrders)
                   .IsRequired();

            builder.Property(x => x.CancelledOrders)
                   .IsRequired();

            builder.Property(x => x.CompletionRate)
                   .HasPrecision(5, 2)
                   .IsRequired();

            builder.Property(x => x.TotalRevenue)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.TotalPlatformFee)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.ComputedAt)
                   .IsRequired();

            builder.HasOne(x => x.Pharmacy)
                   .WithMany(p => p.PharmaPerformSnapshots)
                   .HasForeignKey(x => x.PharmacyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
