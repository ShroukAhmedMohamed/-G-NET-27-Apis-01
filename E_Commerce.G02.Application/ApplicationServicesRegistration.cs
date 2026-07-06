using E_Commerce.G02.Application.Services.Class;
using E_Commerce.G02.Application.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Application
{
    public static class ApplicationServicesRegistration

    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)

        {
            services.AddAutoMapper(c => { }, typeof(ApplicationServicesRegistration).Assembly);



            services.AddScoped<IProductService, ProductService>();


            return services;
        }

      


} 
}
