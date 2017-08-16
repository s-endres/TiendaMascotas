using TiendaMascotas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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


        public static List<User> UserList = new List<User>();

        public static List<UserType> UserTypeList = new List<UserType>()
        {
            new UserType()
            {
                Id = 1,
                Name = "Client"
            },
            new UserType()
            {
                Id = 2,
                Name = "Employee"
            },
        };

        public static List<Bill> BillList = new List<Bill>();

        public static List<Purchase> PurchaseList = new List<Purchase>();

        public static List<Discount> DiscountList = new List<Discount>();

        public static List<DiscountType> DiscountTypeList = new List<DiscountType>();

        public static List<Product> ProductList = new List<Product>();

        public static List<ProductType> ProductTypeList = new List<ProductType>();

        public static List<Category> CategoryList = new List<Category>()
        {
            new Category()
            {
                Id = 1,
                Name = "comida"
            },

            new Category()
            {
                Id = 2,
                Name = "jaula"
            },

            new Category()
            {
                Id = 3,
                Name = "ropa"
            },

            new Category()
            {
                Id = 4,
                Name = "juguete"
            }
        };






    }
}