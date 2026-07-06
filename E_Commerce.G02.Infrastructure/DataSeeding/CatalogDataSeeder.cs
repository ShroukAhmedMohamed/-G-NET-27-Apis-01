using E_Commerce.G02.Domain.Common;
using E_Commerce.G02.Domain.contracts;
using E_Commerce.G02.Domain.Entities.Products;
using E_Commerce.G02.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_Commerce.G02.Infrastructure.DataSeeding
{
    public class CatalogDataSeeder(StoreDbContext context, ILogger<CatalogDataSeeder>logger) : IDataseeder
    {
      public  async Task SeedDataAsync(CancellationToken ct=default)
        {

            try 
            {
                var pendingMigrations = await context.Database.GetPendingMigrationsAsync(cancellationToken: ct);

                if (pendingMigrations.Any())

                {

                    await context.Database.MigrateAsync();


                }

                //seeding
                var seedRootPath = Path.Combine(AppContext.BaseDirectory, "DataSeed");


                // Read Data From JsonFile

                // Convert Json To Object

                // Add To Database



                /////////////////   //////////////////////////  //////////////////////////////


                // Seeding SeedRootPath

                var SeedRootPath =Path.Combine(AppContext.BaseDirectory, "DataSeed");

                // brands

                await SeedIfEmpty<productBrand, int>(seedRootPath, "brands.json", ct);

                // types

                await SeedIfEmpty<ProductType, int>(seedRootPath, "types.json", ct);

                // product

                await SeedIfEmpty<product, int>(seedRootPath, "products.json", ct);

                var count = await context.SaveChangesAsync(ct);

                if (count > 0)

                    logger.LogInformation($"{count} Rows Added");

                else

                    logger.LogInformation($"Database Already Seeded");





            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message);


            }
        }


        private async Task SeedIfEmpty<TEntity, TKet>(string rootPath, string fileName, CancellationToken ct = default) where TEntity :BaseEntity<TKet>

        {


            if (await context.Set<TEntity>().AnyAsync())

            {

               
                 var tableName = typeof(TEntity).Name;
                logger.LogWarning($"Table{tableName} Alraedy Has Data");

                return;

            }


            var filePath = Path.Combine(rootPath, fileName);

            if (!File.Exists(filePath))

            {

                logger.LogWarning($"File (fileName) Not Exists");

                return;

            }

            //seeding

            using var fileStream = File.OpenRead(filePath);

            var options = new JsonSerializerOptions()

                 {

                 PropertyNameCaseInsensitive = true

                 };
    
 
            var data= await JsonSerializer.DeserializeAsync<List<TEntity>>(fileStream, options,ct);

            if (data is not null && data.Any())

                await context.Set<TEntity>().AddRangeAsync(data);





        }




















    }
}
