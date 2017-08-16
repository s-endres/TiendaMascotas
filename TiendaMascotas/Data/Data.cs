using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaMascotas.Models;

namespace TiendaMascotas.Data
{
    public static class Data
    {
        public static List<User> Users = new List<User>()
        {
            new User(){}
        };

        public static List<UserType> UserTypes = new List<UserType>()
        {
            new UserType(){}
        };

        public static List<Discount> Discounts = new List<Discount>()
        {
            new Discount(){}
        };

        public static List<DiscountType> DiscountTypes = new List<DiscountType>()
        {
            new DiscountType(){}
        };

        public static List<Bill> Bills = new List<Bill>()
        {
            new Bill(){}
        };

        public static List<Purchase> Purchases = new List<Purchase>()
        {
            new Purchase(){}
        };

        public static List<Product> Products = new List<Product>()
        {
            new Product(){}
        };

        public static List<ProductType> ProductTypes = new List<ProductType>()
        {
            new ProductType(){}
        };

        public static List<Category> Categories = new List<Category>()
        {
            new Category(){}
        };
    }
}