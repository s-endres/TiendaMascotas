using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaMascotas.Models;

namespace TiendaMascotas.Data
{
    public class ProductTypeData
    {
        public static List<ProductType> ProductTypeList = new List<ProductType>()
        {
            new ProductType() {

                Id = 1,
                TypeName = "Jaja salu2",
                IdCateogry = 1
            }


        };
    }
}