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
    public class BidItemConfiguration : IEntityTypeConfiguration<BidItem>
    {
        public void Configure(EntityTypeBuilder<BidItem> builder)
        {
            builder.ToTable("BidItems");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ItemName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.UnitPrice)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.Quantity)
                   .IsRequired();

            builder.Property(x => x.IsAlternative)
                   .IsRequired();

            builder.Property(x => x.AlternativeNote)
                   .HasMaxLength(500);

            builder.Property(x => x.LineTotal)
                   .HasPrecision(18, 2)
                   .IsRequired();


            builder.HasOne(x => x.Bid)
                   .WithMany(b => b.BidItems)
                   .HasForeignKey(x => x.BidId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
