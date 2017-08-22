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

        public static List<ProductType> ProductTypeList = new List<ProductType>()
        {

            new ProductType()
            {
                Id = 0,
                Name = "Blank",
            },

            new ProductType()
            {
                Id = 1,
                Name = "Small cage",
                CategoryId = 2
            },

            new ProductType()
            {
                Id = 2,
                Name = "Dog shirt",
                CategoryId = 3
            },

            new ProductType()
            {
                Id = 3,
                Name = "Rubber Bone",
                CategoryId = 4
            },

            new ProductType()
            {
                Id = 4,
                Name = "Dog food",
                CategoryId = 1
            }
        };

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
                Name = "cage"
            },

            new Category()
            {
                Id = 3,
                Name = "Clothes"
            },

            new Category()
            {
                Id = 4,
                Name = "toy"
            }
        };






    }
}