using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaMascotas.Models;

namespace TiendaMascotas.Data
{
    public static class Data
    {
        //Ejemplo lista de valores
        //public static List<Estidad> Entidades = new List<Estidad>()
        //{
        //    new Entidad()
        //    {
        //        variable1 = "12",
        //        variable2 = "asdasd"
        //    }
        //};

        public static List<Category> Categories = new List<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "Comida"
            },
            new Category()
            {
                Id = 2,
                Name = "Jaula"
            },
            new Category()
            {
                Id = 3,
                Name = "Ropa"
            },
            new Category()
            {
                Id = 4,
                Name = "Juguete"
            }
        };

        public static List<ProductType> ProductTypes = new List<ProductType>(){ };

        public static List<Product> Products = new List<Product>() { };

        public static List<UserType> UserTypes = new List<UserType>() { };

        public static List<User> Users = new List<User>() { };

        public static List<Purchase> Purchases = new List<Purchase>() { };

        public static List<Discount> Discounts = new List<Discount>() { };

        public static List<DiscountType> DiscountType = new List<DiscountType>() { };

        public static List<Bill> Bills = new List<Bill>() { };

    }
}