using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            #endregion


            #region Repository and UnitofWork
            #endregion


            #region Servics
            #endregion


            #region AutoMapper and Validation

            #endregion

            return services;
        }
    }
}
