using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaLink.Domain.Entities.UserAccess;

namespace PharmaLink.Infrastructure.Data.Configurations.OrdersOperationsConfig
{
    public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.ToTable("Complaints");

            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
            builder.Property(c => c.AdminNotes).HasMaxLength(500);

            builder.Property(c => c.Status)
                   .HasConversion<string>()
                   .HasMaxLength(50);

            //  Relationships

            builder.HasOne(c => c.Order)
                   .WithMany(o => o.Complaints)
                   .HasForeignKey(c => c.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Complaint -> SubmittedBy (ApplicationUser)
            builder.HasOne(c => c.SubmittedBy)
                   .WithMany(u => u.Complaints)
                   .HasForeignKey(c => c.SubmittedById)
                   .OnDelete(DeleteBehavior.Restrict);

            // Complaint -> ResolvedBy (ApplicationUser)
            builder.HasOne(c => c.ResolvedBy)
                   .WithMany(u => u.ResolvedComplaints)
                   .HasForeignKey(c => c.ResolvedById)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
