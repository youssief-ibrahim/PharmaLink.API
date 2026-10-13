
using System.Threading.Tasks;
using PharmaLink.API.CustomMiddleWare;
using PharmaLink.API.Extentions;

namespace PharmaLink.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddApplicationServices(builder.Configuration);

            builder.Services.AddDataProtection();

            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.Services.AddSwaggerDocumentation();

            var app = builder.Build();

            #region seding data
            await app.MigrateDatabaseAsync();
            await app.SeedDataAsync();
            #endregion
            app.UseMiddleware<ExceptionHandlerMiddleWare>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
