using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotas.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ANCode { get; set; } 
        public string Name { get; set; }
        public double Cost { get; set; }
        public Boolean isSold { get; set; }
        public int ProductType { get; set; }
    }
}