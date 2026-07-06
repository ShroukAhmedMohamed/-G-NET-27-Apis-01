using E_Commerce.G02.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<product> builder)
        {
            builder.Property(P => P.Name)
               .HasMaxLength(100);

            builder.Property(P => P.Description)
                .HasMaxLength(500);

            builder.Property(P => P.PictureUrl)
                .HasMaxLength(200);

            builder.Property(P => P.Price)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(P => P.Brand)
                .WithMany()

              .HasForeignKey(P => P.BrandId);

            builder.HasOne(P => P.Type)

                    .WithMany()

              .HasForeignKey(P => P.TypeId);









        }
    }
}
