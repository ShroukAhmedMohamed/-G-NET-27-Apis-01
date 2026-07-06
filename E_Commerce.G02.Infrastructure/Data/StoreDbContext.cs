using E_Commerce.G02.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static E_Commerce.G02.Infrastructure.Data.StoreDbContext;

namespace E_Commerce.G02.Infrastructure.Data
{
    



      

        public class StoreDbContext(DbContextOptions<StoreDbContext> options): DbContext(options)
        {
            public DbSet<product> Products { get; set; }

            public DbSet<productBrand> ProductBrands { get; set; }

            public DbSet<ProductType> ProductTypes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StoreDbContext).Assembly);


            base.OnModelCreating(modelBuilder);

          




        }
        }
    }
