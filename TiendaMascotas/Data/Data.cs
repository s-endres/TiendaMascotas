using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaMascotas.Models;

namespace TiendaMascotas.Data
{
    public class Data
    {
        public static List<Category> Categories = new List<Category>() {
            new Category(){ Id = 1, Name = "Food", IsDeleted = false },
            new Category(){ Id = 2, Name = "Cage", IsDeleted = false },
            new Category(){ Id = 3, Name = "Cloth", IsDeleted = false },
            new Category(){ Id = 4, Name = "Toy", IsDeleted = false }
        };

        public static List<ProductType> ProductTypesLst = new List<ProductType>() {
            new ProductType(){ Id = 1, IdCategory = 1, Name = "Sea food", IsDeleted = false },
            new ProductType(){ Id = 2, IdCategory = 1, Name = "Beef", IsDeleted = false },
            new ProductType(){ Id = 3, IdCategory = 1, Name = "Vegetable", IsDeleted = false },
            new ProductType(){ Id = 4, IdCategory = 2, Name = "Small cage", IsDeleted = false },
            new ProductType(){ Id = 5, IdCategory = 2, Name = "Big cage", IsDeleted = false },
            new ProductType(){ Id = 6, IdCategory = 3, Name = "Scarf", IsDeleted = false },
            new ProductType(){ Id = 7, IdCategory = 3, Name = "Shoes", IsDeleted = false },
            new ProductType(){ Id = 8, IdCategory = 3, Name = "Gloves", IsDeleted = false },
            new ProductType(){ Id = 9, IdCategory = 4, Name = "Lego", IsDeleted = false }
        };

        public static List<DiscountType> DiscountTypesList = new List<DiscountType>() {
            new DiscountType() { Id = 1, Name = "Discount by buying the favorite category", Value = 5 },
            new DiscountType() { Id = 2, Name = "Bought more than 25 products", Value = 5 },
            new DiscountType() { Id = 3, Name = "Bought more than 50 products", Value = 10 },
            new DiscountType() { Id = 4, Name = "Bought more than 100 products", Value = 15 }
        };

        public static List<UserType> UserTypesList = new List<UserType>()
        {
            new UserType() { Id = 1, Name = "Admin" },
            new UserType() { Id = 2, Name = "Client" }
        };
    }
}