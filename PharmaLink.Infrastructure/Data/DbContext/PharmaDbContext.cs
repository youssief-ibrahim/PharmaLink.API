using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmaLink.Domain.Entities.Pharma_Requests;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Domain.Entities.UserAccess;

namespace PharmaLink.Infrastructure.Data.DbContext
{
    public class PharmaDbContext : IdentityDbContext<ApplicationUser>
    {
        public PharmaDbContext(DbContextOptions<PharmaDbContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(PharmaDbContext).Assembly);
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        }
    }
}
