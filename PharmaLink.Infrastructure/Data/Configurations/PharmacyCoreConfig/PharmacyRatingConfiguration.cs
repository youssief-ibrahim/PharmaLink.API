using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaLink.Domain.Entities.UserAccess;

namespace PharmaLink.Infrastructure.Data.Configurations.PharmacyCoreConfig
{
    public class PharmacyRatingConfiguration : IEntityTypeConfiguration<PharmacyRating>
    {
        public void Configure(EntityTypeBuilder<PharmacyRating> builder)
        {
            builder.ToTable("PharmacyRatings");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RatingValue)
                   .IsRequired();

            builder.Property(x => x.Comment)
                   .HasMaxLength(500);

            builder.HasIndex(x => x.OrderId)
                    .IsUnique();

            builder.HasOne(x => x.Order)
                   .WithOne(o => o.PharmacyRating)
                   .HasForeignKey<PharmacyRating>(x => x.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Pharmacy)
                   .WithMany(p => p.PharmacyRatings)
                   .HasForeignKey(x => x.PharmacyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.PatientProfile)
                   .WithMany(p => p.PharmacyRatings)
                   .HasForeignKey(x => x.PatientProfileId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
