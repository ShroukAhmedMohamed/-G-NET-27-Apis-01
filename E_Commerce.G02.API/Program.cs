
using E_Commerce.G02.API.Extentions;
using E_Commerce.G02.Application;
using E_Commerce.G02.Domain.contracts;
using E_Commerce.G02.Infrastructure;
using Microsoft.Extensions.FileProviders;

namespace E_Commerce.G02.API
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
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddSwaggerGen();
            



                var app = builder.Build();


                await app.SeedAndMigrationDataAsync();





                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                   
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

            app.UseStaticFiles(new StaticFileOptions()

            {

                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Files"))
              
            });


                app.UseHttpsRedirection();

                app.UseAuthorization();


                app.MapControllers();

                app.Run();
            }
      
    
    
    }
}




