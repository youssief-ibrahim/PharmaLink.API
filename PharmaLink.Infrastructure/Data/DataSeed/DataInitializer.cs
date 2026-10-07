using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PharmaLink.Domain.Contracts;
using PharmaLink.Domain.Entities.User;
using PharmaLink.Infrastructure.Data.DbContext;

namespace PharmaLink.Infrastructure.Data.DataSeed
{
    public class DataInitializer : IDataInitializer
    {
        private readonly PharmaDbContext dbcontext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<DataInitializer> logger;
        private readonly IConfiguration configuration;
        public DataInitializer(PharmaDbContext _dbcontext,
                                UserManager<ApplicationUser> _userManager,
                                RoleManager<IdentityRole> _roleManager,
                                IConfiguration _configuration,
                                ILogger<DataInitializer> _logger)
        {
            dbcontext = _dbcontext;
            userManager = _userManager;
            roleManager = _roleManager;
            configuration = _configuration;
            logger = _logger;
        }
        public async Task InitializeAsync()
        {
            try
            {
                await SeederAsync.SeedRolesAsync(roleManager);
                await SeederAsync.SeedAdminUserAsync(userManager);
                //var enableDemoData = configuration.GetValue<bool>("Seeding:EnableDemoData");
                var enableDemoData = bool.Parse(configuration["Seeding:EnableDemoData"] ?? "true");
                if (enableDemoData)
                {
                    await SeederAsync.SeedDummyUsersAsync(userManager);
                    await SeederAsync.SeedOrderTestDataAsync(dbcontext);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while initializing the database.");
            }
        }
    }
}
