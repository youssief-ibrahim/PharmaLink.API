using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaLink.Application.IServices;
using PharmaLink.Application.MappingProfile;
using PharmaLink.Application.Services;
using PharmaLink.Domain.Contracts;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Infrastructure.Data.DataSeed;
using PharmaLink.Infrastructure.Data.DbContext;
using PharmaLink.Infrastructure.Repositories;

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
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion


            #region Servics
            services.AddScoped<IDataInitializer, DataInitializer>();
            services.AddScoped<IPrescriptionRequestService, PrescriptionRequestService>();
            #endregion


            #region AutoMapper and Validation
            services.AddAutoMapper(cfg => { }, typeof(PrescriptionRequestMapping).Assembly);
            #endregion

            return services;
        }
    }
}
