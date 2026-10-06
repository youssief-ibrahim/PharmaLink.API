using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PharmaLink.Domain.Entities.User;

namespace PharmaLink.Infrastructure.Data.Configurations.User_Profiles
{
    public class PharmaOwnerConfiguration : IEntityTypeConfiguration<PharmaOwner>
    {
        public void Configure(EntityTypeBuilder<PharmaOwner> builder)
        {
            builder.ToTable("PharmaOwners");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NationalId)
                .HasMaxLength(20);

            builder.Property(x => x.NationalIdFront)
                .HasMaxLength(500);

            builder.Property(x => x.NationalIdBack)
                .HasMaxLength(500);

            builder.Property(x => x.SyndicateCardImage)
                .HasMaxLength(500);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.HasOne(x => x.ApplicationUser)
                .WithOne(x => x.PharmaOwnerProfile)
                .HasForeignKey<PharmaOwner>(x => x.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
