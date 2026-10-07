using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaLink.Domain.Contracts;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Infrastructure.Data.DataSeed;
using PharmaLink.Infrastructure.Data.DbContext;

namespace PharmaLink.API.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Database
            //  Database
            services.AddDbContext<PharmaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            // Identity 
            services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;

                options.SignIn.RequireConfirmedEmail = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PharmaDbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(
                TokenOptions.DefaultProvider);

            #endregion


            #region Repository and UnitofWork
            #endregion


            #region Servics
            services.AddScoped<IDataInitializer, DataInitializer>();
            #endregion


            #region AutoMapper and Validation

            #endregion

            return services;
        }
    }
}
