using E_Commerce.G02.Domain.contracts;
using E_Commerce.G02.Infrastructure.Data;
using E_Commerce.G02.Infrastructure.DataSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Infrastructure
{
  public  static class InfrastructureServicesRegistration
    {

public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<StoreDbContext>(options =>

             {

              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            });


           

            services.AddKeyedScoped<IDataseeder, CatalogDataSeeder>("Catalog");


            services.AddScoped<IUnitOfWork, UnitOfWork>();




            return services;
            










        }


    }
}
