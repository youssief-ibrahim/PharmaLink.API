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
    public class PatientProfileConfiguration : IEntityTypeConfiguration<PatientProfile>
    {
        public void Configure(EntityTypeBuilder<PatientProfile> builder)
        {
            builder.ToTable("PatientProfiles");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ApplicationUser)
                .WithOne(x => x.PatientProfile)
                .HasForeignKey<PatientProfile>(x => x.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
