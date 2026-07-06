using E_Commerce.G02.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.G02.Domain.Entities.Products
{
    public class product : BaseEntity<int>
    {

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;



        public string PictureUrl { get; set; } = default!;



        public decimal Price { get; set; }

     

           public int BrandId { get; set; } = default!;



        public productBrand Brand { get; set; }


        public int TypeId { get; set; }
       
           public ProductType Type { get; set; } = default!;











    }
}
