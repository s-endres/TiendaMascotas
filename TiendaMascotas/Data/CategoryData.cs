using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaMascotas.Models;

namespace TiendaMascotas.Data
{
    public class CategoryData
    {
        public static List<Category> CategoryList = new List<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "Food"
            },
            new Category()
            {
                Id = 2,
                Name = "Cage"
            },
            new Category()
            {
                Id = 3,
                Name = "Clothes"
            },
            new Category()
            {
                Id = 4,
                Name = "Toys"
            }



        };
    }
}