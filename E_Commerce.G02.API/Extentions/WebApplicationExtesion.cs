using E_Commerce.G02.Domain.contracts;
using Microsoft.Extensions.Hosting.Internal;
using System.Runtime.CompilerServices;

namespace E_Commerce.G02.API.Extentions
{
    public  static class WebApplicationExtesion
    {
        public static async Task<WebApplication> SeedAndMigrationDataAsync(this WebApplication app )
        {
           


            using var scope = app.Services.CreateScope();

            var dataSeeder = scope.ServiceProvider.GetRequiredKeyedService<IDataseeder>("Catalog");

            await dataSeeder.SeedDataAsync();


            return app;



        }

        }
    }
